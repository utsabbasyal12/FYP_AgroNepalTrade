using FYP_AgroNepalTrade.BlogManagers.Interfaces;
using FYP_AgroNepalTrade.Models.AuthorViewModels;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using FYP_AgroNepalTrade.Models.Services;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.BlogManagers
{
    public class BlogHomeBusinessManager : IBlogHomeBusinessManager
    {
        private readonly IBlogService blogService;
        private readonly IUserService userService;

        public BlogHomeBusinessManager(
            IBlogService blogService,
            IUserService userService)
        {
            this.blogService = blogService;
            this.userService = userService;
        }

        public ActionResult<AuthorViewModel> GetAuthorViewModel(string authorId, string searchString, int? page)
        {
            if (authorId is null)
                return new BadRequestResult();

            var applicationUser = userService.Get(authorId);

            if (applicationUser is null)
                return new NotFoundResult();

            int pageSize = 20;
            int pageNumber = page ?? 1;

            var blogs = blogService.GetBlogs(searchString ?? string.Empty)
                .Where(blog => blog.Published && blog.Creator == applicationUser && blog.Approved);

            return new AuthorViewModel
            {
                Author = applicationUser,
                Blogs = new StaticPagedList<Blog>(blogs.Skip((pageNumber - 1) * pageSize).Take(pageSize), pageNumber, pageSize, blogs.Count()),
                SearchString = searchString,
                PageNumber = pageNumber
            };
        }
    }
}
