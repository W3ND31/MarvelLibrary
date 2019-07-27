using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarvelLibrary.Data;
using MarvelLibrary.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using MarvelLibrary.Services;
using MarvelLibrary.Utilities;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace MarvelLibrary.Controllers
{
    public class AccountsController : Controller
    {
        private readonly MarvelLibraryContext _context;
        private readonly AccountService _accountService;

        public AccountsController(MarvelLibraryContext context, AccountService accountService)
        {
            _context = context;
            _accountService = accountService;

            if (!_accountService.CheckUser("admin"))
            {
                Account admin = new Account("Admin", "admin@2019", "admin@admin.com", "Administrator");
                _context.Add(admin);
                _context.SaveChanges();
            }
        }


        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.msg = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserLogin([Bind] Account acc)
        {
            //string login, string pwd
            if (LoginUser(acc.Login, acc.Password) == 1)
            {
                var account = _accountService.GetAccount(acc.Login);

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, account.Login),
                    new Claim(ClaimTypes.NameIdentifier, account.Name),
                    new Claim(ClaimTypes.Email, account.Email),
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                };

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);

                //Just redirect to our home index after logging in. 
                return Redirect("../Home/Index");
            }
            else if (LoginUser(acc.Login, acc.Password) == 0)
            {
                return RedirectToAction(nameof(Login), TempData["UserLoginFailed"] = "Incorrect Password");
            }
            else
            {
                return RedirectToAction(nameof(Login), TempData["UserLoginFailed"] = "User does not exists!");
            }


        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterUser([Bind] Account acc)
        {
            if (ModelState.IsValid)
            {
                int status = _accountService.SignUp(acc);
                if (status == 1)
                {
                    ModelState.Clear();
                    TempData["Success"] = "Registration Successful!";
                    return RedirectToAction(nameof(Login), TempData["RegisterSucceed"] = "Registered successfully! You can login now!");
                }
                else
                {
                    TempData["Fail"] = "This User ID already exists. Registration Failed.";
                    return View();
                }
            }
            return View(nameof(Register), TempData["DataInvalid"] = "Invalid data inserted. Please verify your data!");
        }

        private int LoginUser(string username, string password)
        {
            string hash = Md5Hash.GetMd5Hash(MD5.Create(), password);
            return _accountService.SignIn(username, hash);
        }
    }
}
