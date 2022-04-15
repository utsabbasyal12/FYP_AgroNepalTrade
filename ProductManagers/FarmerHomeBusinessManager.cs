using FYP_AgroNepalTrade.Models.FarmerViewModels;
using FYP_AgroNepalTrade.Models.ProductViewModels;
using FYP_AgroNepalTrade.Models.Services;
using FYP_AgroNepalTrade.ProductManagers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.ProductManagers
{
    public class FarmerHomeBusinessManager : IFarmerHomeBusinessManager
    {
        private readonly IProductService productService;
        private readonly IUserService userService;

        public FarmerHomeBusinessManager(IProductService productService, IUserService userService)
        {
            this.productService = productService;
            this.userService = userService;
        }
        public ActionResult<FarmerViewModel> GetFarmerViewModel(string farmerId, string searchString, int? page)
        {
            if (farmerId is null)
                return new BadRequestResult();

            var applicationUser = userService.Get(farmerId);

            if (applicationUser is null)
                return new NotFoundResult();

            int pageSize = 20;
            int pageNumber = page ?? 1;

            var products = productService.GetProducts(searchString ?? string.Empty)
                .Where(product => product.Published && product.Farmer == applicationUser);

            return new FarmerViewModel
            {
                Farmer = applicationUser,
                Products = new StaticPagedList<Product>(products.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, products.Count()),
                SearchString = searchString,
                PageNumber = pageNumber
            };
        }

    }
}
