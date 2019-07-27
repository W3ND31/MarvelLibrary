using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MarvelLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using MarvelLibrary.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace MarvelLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountService _accountService;
        private readonly IHttpContextAccessor _httpContext;

        public HomeController(AccountService accountService, IHttpContextAccessor httpContext)
        {
            _accountService = accountService;
            _httpContext = httpContext;
        }

        public IActionResult Index()
        {
            ViewBag.User = _accountService.GetNameUserLogged();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _httpContext.HttpContext.SignOutAsync();
            return RedirectToAction("Login","Accounts");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
