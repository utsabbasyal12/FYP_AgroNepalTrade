using AgroNepalTrade.Data;
using AgroNepalTrade.Models;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FYP_AgroNepalTrade.Models.Services
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public BlogService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Blog> Add(Blog blog)
        {
            applicationDbContext.Add(blog);
            await applicationDbContext.SaveChangesAsync();
            return blog;
        }
    }
}
