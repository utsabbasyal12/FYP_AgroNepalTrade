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

        public FarmerController(IFarmerBusinessManager farmerBusinessManager)
        {
            this.farmerBusinessManager = farmerBusinessManager;
        }
        public async Task<IActionResult> Index()
        {
            return View(await farmerBusinessManager.GetFarmerDashboard(User));
        }
    }
}
