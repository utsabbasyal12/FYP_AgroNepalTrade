using AgroNepalTrade.Enums;
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
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IProductBusinessManager productBusinessManager;

        public CustomerController(IWebHostEnvironment webHostEnvironment, IProductBusinessManager productBusinessManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.productBusinessManager = productBusinessManager;
        }
        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult SendRequest()
        {
            return View();
        }
       /* public async Task<IActionResult> SendRequest(int? id)
        {
            var actionResult = await productBusinessManager.GetProductViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }*/
    }
}
