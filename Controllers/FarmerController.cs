using FYP_AgroNepalTrade.Models.FarmerViewModels;
using FYP_AgroNepalTrade.ProductManagers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Controllers
{
    [Authorize]
    public class FarmerController : Controller
    {
        private readonly IFarmerBusinessManager farmerBusinessManager;
        private readonly IFarmerHomeBusinessManager farmerHomeBusinessManager;

        public FarmerController(IFarmerBusinessManager farmerBusinessManager, IFarmerHomeBusinessManager farmerHomeBusinessManager)
        {
            this.farmerBusinessManager = farmerBusinessManager;
            this.farmerHomeBusinessManager = farmerHomeBusinessManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await farmerBusinessManager.GetFarmerDashboard(User));
        }
        public IActionResult Farmer(string farmerId, string searchString, int? page)
        {
            var actionResult = farmerHomeBusinessManager.GetFarmerViewModel(farmerId, searchString, page);
            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }
        public async Task<IActionResult> About()
        {
            return View(await farmerBusinessManager.GetAboutViewModel(User));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutViewModel aboutViewModel)
        {
            await farmerBusinessManager.UpdateAbout(aboutViewModel, User);
            return RedirectToAction("About");
        }
    }
}
