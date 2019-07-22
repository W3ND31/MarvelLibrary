using MarvelLibrary.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var client = new RestClient("https://gateway.marvel.com:443/v1/public");
            var request = new RestRequest($"/characters?apikey={apiKey}");
            var response = client.Get(request);
            var content = response.Content;

        }
    }
}
