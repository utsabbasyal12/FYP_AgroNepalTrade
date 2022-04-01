using FYP_AgroNepalTrade.BlogManagers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FYP_AgroNepalTrade.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IAuthorBusinessManager authorBusinessManager;

        public AuthorController(IAuthorBusinessManager authorBusinessManager)
        {
            this.authorBusinessManager = authorBusinessManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await authorBusinessManager.GetAuthorDashboard(User));
        }
    }
}
