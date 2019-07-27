using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelLibrary.Data;
using MarvelLibrary.Utilities;
using MarvelLibrary.Models;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading;

namespace MarvelLibrary.Services
{
    public class AccountService
    {
        private readonly MarvelLibraryContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(MarvelLibraryContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public int SignIn(string username, string pwdHash)
        {
            Account user = new Account();
            user = _context.Account.Find(username);

            if(user == null)
            {
                return -1;
            }

            if(pwdHash == user.PwHash)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int SignUp(Account acc)
        {
            Account a = new Account(acc.Login, acc.Password, acc.Email, acc.Name);
            _context.Add(a);
            return _context.SaveChanges();
        }

        public bool CheckUser(string username)
        {
            return _context.Account.Any(e => e.Login == username);
        }

        public Account GetAccount(string username)
        {
            Account acc = _context.Account.Find(username);
            return acc;
        }
        public string GetUserLogged()
        {
            var loggedInUserName = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

            if (loggedInUserName == null)
            {
                loggedInUserName = "Anonymous User";
            }

            return loggedInUserName;
            //return tete;
        }

        public string GetNameUserLogged()
        {
            var loggedInUserName = _httpContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            return loggedInUserName;
        }
    }
}
