using FYP_AgroNepalTrade.Models.ProductViewModels;
using FYP_AgroNepalTrade.ProductManagers;
using FYP_AgroNepalTrade.ProductManagers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Controllers
{
    public class ProductController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductBusinessManager productBusinessManager;

        public ProductController(IWebHostEnvironment webHostEnvironment, IProductBusinessManager productBusinessManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.productBusinessManager = productBusinessManager;
        }
        [HttpGet]
        public IActionResult Index(string searchString, int? page)
        {
            return View(productBusinessManager.GetIndexViewModel(searchString, page));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            var actionResult = await productBusinessManager.GetProductViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }
        [Authorize(Roles = "Farmer")]
        public IActionResult Create()
        {
            return View(new CreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createViewModel)
        {
            await productBusinessManager.CreateProduct(createViewModel, User);
            return RedirectToAction("Create");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var actionResult = await productBusinessManager.GetEditViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }
        [HttpPost]
        public async Task<IActionResult> Update(EditViewModel editViewModel)
        {
            var actionResult = await productBusinessManager.UpdateProduct(editViewModel, User);

            if (actionResult.Result is null)
                return RedirectToAction("Edit", new { editViewModel.Product.Id });

            return actionResult.Result;
        }
    }
}
