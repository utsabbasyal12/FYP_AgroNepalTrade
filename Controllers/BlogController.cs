using FYP_AgroNepalTrade.BlogManagers.Interfaces;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using FYP_AgroNepalTrade.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogBusinessManager blogBusinessManager;
        private readonly IBlogHomeBusinessManager blogHomeBusinessManager;

        public BlogController(IBlogBusinessManager blogBusinessManager, IBlogHomeBusinessManager blogHomeBusinessManager)
        {
            this.blogBusinessManager = blogBusinessManager;
            this.blogHomeBusinessManager = blogHomeBusinessManager;
        }
        // GET: BlogController
        [HttpGet]
        
        public IActionResult Index(string searchString, int? page)
        {
            return View(blogBusinessManager.GetIndexViewModel(searchString, page));
        }
        public IActionResult Author(string authorId, string searchString, int? page)
        {
            var actionResult = blogHomeBusinessManager.GetAuthorViewModel(authorId, searchString, page);
            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }
        /*  [Route("Blog/{id}")]*/
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            var actionResult = await blogBusinessManager.GetBlogViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }

        // GET: BlogController/Create
        [Authorize(Roles = "Author")]
        public ActionResult CreateBlog()
        {
            return View(new CreateViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateViewModel createViewModel)
        {
            await blogBusinessManager.CreateBlog(createViewModel, User);
            return RedirectToAction("CreateBlog");
        } 

        // GET: BlogController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var actionResult = await blogBusinessManager.GetEditViewModel(id, User);

            if (actionResult.Result is null)
                return View(actionResult.Value);

            return actionResult.Result;
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditViewModel editViewModel)
        {
            var actionResult =  await blogBusinessManager.UpdateBlog(editViewModel, User);

            if (actionResult.Result is null)
                return RedirectToAction("Edit", new { editViewModel.Blog.Id });

            return actionResult.Result;
        }
        [HttpPost]
        public async Task<IActionResult> Comment(BlogViewModel blogViewModel)
        {
            var actionResult = await blogBusinessManager.CreateComment(blogViewModel, User);

            if (actionResult.Result is null)
                return RedirectToAction("Details", new { blogViewModel.Blog.Id });

            return actionResult.Result;
        }

    }
}
