using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.BlogManagers.Interfaces;
using FYP_AgroNepalTrade.Models.AuthorViewModels;
using FYP_AgroNepalTrade.Models.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.BlogManagers
{
    public class AuthorBusinessManager : IAuthorBusinessManager
    {
        private UserManager<ApplicationUser> userManager;
        private IBlogService blogService;

        public AuthorBusinessManager(UserManager<ApplicationUser> userManager, IBlogService blogService)
        {
            this.userManager = userManager;
            this.blogService = blogService;
        }
        public async Task<IndexViewModel> GetAuthorDashboard(ClaimsPrincipal claimsPrincipal)
        {
            var applicationUser = await userManager.GetUserAsync(claimsPrincipal);
            return new IndexViewModel
            {
                Blogs = blogService.GetBlogs(applicationUser)

            };
        }
    }
}
