using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.BlogManagers.Interfaces;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using FYP_AgroNepalTrade.Models.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.BlogManagers
{
    public class BlogBusinessManager : IBlogBusinessManager
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBlogService blogService;

        public BlogBusinessManager(UserManager<ApplicationUser> userManager, IBlogService blogService)
        {
            this.userManager = userManager;
            this.blogService = blogService;
        }
        public async Task<Blog> CreateBlog(CreateViewModel createViewModel, ClaimsPrincipal claimsPrincipal)
        {
            Blog blog = createViewModel.Blog;

            blog.Author = await userManager.GetUserAsync(claimsPrincipal);
            blog.CreatedOn = DateTime.Now;
            
            return await blogService.Add(blog);

            
        }
    }
}
