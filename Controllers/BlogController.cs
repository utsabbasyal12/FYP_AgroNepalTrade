using FYP_AgroNepalTrade.BlogManagers.Interfaces;
using FYP_AgroNepalTrade.Models.BlogViewModels;
using FYP_AgroNepalTrade.Models.Services;
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
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IBlogBusinessManager blogBusinessManager;

        public BlogController(IWebHostEnvironment webHostEnvironment, IBlogBusinessManager blogBusinessManager)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.blogBusinessManager = blogBusinessManager;
        }
        // GET: BlogController
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        // GET: BlogController/Create
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


    }
}
