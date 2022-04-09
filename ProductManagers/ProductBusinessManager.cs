using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Authorization;
using FYP_AgroNepalTrade.Models.ProductViewModels;
using FYP_AgroNepalTrade.Models.Services;
using FYP_AgroNepalTrade.ProductManagers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.ProductManagers
{
    public class ProductBusinessManager : IProductBusinessManager
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductService productService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAuthorizationService authorizationService;

        public ProductBusinessManager(UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment, IAuthorizationService authorizationService, IProductService productService)
        {
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
            this.authorizationService = authorizationService;
            this.productService = productService;
        }
        public IndexViewModel GetIndexViewModel(string searchString, int? page)
        {
            int pageSize = 10;
            int pageNumber = page ?? 1;
            var product = productService.GetProducts(searchString ?? string.Empty)
                .Where(product => product.Published); ;


            return new IndexViewModel
            {
                Products = new StaticPagedList<Product>(product.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, product.Count()),
                SearchString = searchString,
                PageNumber = pageNumber
            };
        }
        public async Task<ActionResult<ProductViewModel>> GetProductViewModel(int? id, ClaimsPrincipal claimsPrincipal)
        {
            if (id is null)
                return new BadRequestResult();

            var productId = id.Value;

            var product = productService.GetProduct(productId);

            if (product is null)
                return new NotFoundResult();

            if (!product.Published)
            {
                var authorizationResult = await authorizationService.AuthorizeAsync(claimsPrincipal, product, Operations.Read);

                if (!authorizationResult.Succeeded)
                    return DetermineActionResult(claimsPrincipal);
            }
            return new ProductViewModel
            {
                Product = product
            };
        }
        public async Task<Product> CreateProduct(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal)
        {
            Product product = createViewModel.Product;

            product.Farmer = await userManager.GetUserAsync(claimsPrincipal);
            product.CreatedOn = DateTime.Now;
            product.UpdatedOn = DateTime.Now;

            product = await productService.Add(product);

            string webRootPath = webHostEnvironment.WebRootPath;
            string pathToImage = $@"{webRootPath}\UserFiles\Products\{product.Id}\HeaderImage.jpg";

            EnsureFolder(pathToImage);
            using (var fileStream = new FileStream(pathToImage, FileMode.Create))
            {
                await createViewModel.HeaderImage.CopyToAsync(fileStream);
            }
            return product;
        }
        public async Task<ActionResult<EditViewModel>> UpdateProduct(EditViewModel editViewModel, ClaimsPrincipal claimsPrincipal)
        {
            var product = productService.GetProduct(editViewModel.Product.Id);
            if (product is null)
                return new NotFoundResult();

            var authorizationResult = await authorizationService.AuthorizeAsync(claimsPrincipal, product, Operations.Update);
            if (!authorizationResult.Succeeded)
                return DetermineActionResult(claimsPrincipal);

            product.Published = editViewModel.Product.Published;
            product.ProductName = editViewModel.Product.ProductName;
            product.Quantity = editViewModel.Product.Quantity;
            product.PricePerUnit = editViewModel.Product.PricePerUnit;
            product.UpdatedOn = DateTime.Now;

            if (editViewModel.HeaderImage != null)
            {
                string webRootPath = webHostEnvironment.WebRootPath;
                string pathToImage = $@"{webRootPath}\UserFiles\Products\{product.Id}\HeaderImage.jpg";

                EnsureFolder(pathToImage);

                using (var fileStream = new FileStream(pathToImage, FileMode.Create))
                {
                    await editViewModel.HeaderImage.CopyToAsync(fileStream);
                }
            }
            return new EditViewModel
            {
                Product = await productService.Update(product)
            };
        }
        public async Task<ActionResult<EditViewModel>> GetEditViewModel(int? id, ClaimsPrincipal claimsPrincipal)
        {
            if (id is null)
                return new BadRequestResult();

            var productId = id.Value;
            var product = productService.GetProduct(productId);

            if (product is null)
                return new NotFoundResult();

            var authorizationResult = await authorizationService.AuthorizeAsync(claimsPrincipal, product, Operations.Update);

            if (!authorizationResult.Succeeded)
                return DetermineActionResult(claimsPrincipal);

            return new EditViewModel
            {
                Product = product
            };
        }

        private void EnsureFolder(string path)
        {
            string directoryName = Path.GetDirectoryName(path);
            if (directoryName.Length > 0)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
        }
        private ActionResult DetermineActionResult(ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal.Identity.IsAuthenticated)
                return new ForbidResult();
            else
                return new ChallengeResult();
        }
    }
}
