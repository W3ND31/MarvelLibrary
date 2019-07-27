using MarvelLibrary.Data;
using MarvelLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MarvelLibrary.Services;

namespace MarvelLibrary.Models
{
    public class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PwHash { get; set; }

        public Account()
        {
        }

        public Account(string login, string password, string email, string name)
        {
            Login = login;
            Password = password;
            Email = email;
            Name = name;
            PwHash = Md5Hash.GetMd5Hash(MD5.Create(), password);
        }
    }
}
