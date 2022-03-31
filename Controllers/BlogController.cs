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

        // GET: BlogController/Details/5
        public ActionResult Details(int id)
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
            return View("CreateBlog", createViewModel);
        } 
        // POST: BlogController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
