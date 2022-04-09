using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.FarmerViewModels;
using FYP_AgroNepalTrade.Models.Services;
using FYP_AgroNepalTrade.ProductManagers.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.ProductManagers
{
    public class FarmerBusinessManager : IFarmerBusinessManager
    {
        private UserManager<ApplicationUser> userManager;
        private IProductService productService;

        public FarmerBusinessManager(IProductService productService, UserManager<ApplicationUser> userManager)
        {
            this.productService = productService;
            this.userManager = userManager;
        }
        public async Task<IndexViewModel> GetFarmerDashboard(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel
            {
                Product = productService.GetProducts(applicationUser)

            };
        }
    }
}
