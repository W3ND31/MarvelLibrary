using MarvelLibrary.Models;
using RestSharp;
using System;
using System.Security.Cryptography;
using MarvelLibrary.Utilities;

namespace MarvelLibrary.Data
{
    public class SeedingCharacters
    {
        private MarvelLibraryContext _context;

        public SeedingCharacters(MarvelLibraryContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            string apiKey = "8a67731f0dd52a1b7260c3f159b92e2b";
            DateTime ts = DateTime.Now;
            string privateKey = "2d9b34399dd38c7ced59ab126c7d74b1e51efc5d";
            string hash;
            string input = $"{ts}{privateKey}{apiKey}";
            MD5 md5 = MD5.Create();
            hash = Md5Hash.GetMd5Hash(md5, input);
            
            var client = new RestClient("https://gateway.marvel.com:443/v1/public");
            var request = new RestRequest($"/characters?apikey={apiKey}");
            var response = client.Get(request);
            var content = response.Content;

        }
    }
}
