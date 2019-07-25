using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using MarvelLibrary.Utilities;
using RestSharp;

namespace MarvelLibrary.Services
{
    public class RestServices
    {
        static readonly string apiKey = "8a67731f0dd52a1b7260c3f159b92e2b";
        static readonly string privateKey = "2d9b34399dd38c7ced59ab126c7d74b1e51efc5d";
        static DateTime ts = DateTime.Now;
        static string input = $"{ts}{privateKey}{apiKey}";
        static string hash = Md5Hash.GetMd5Hash(MD5.Create(), input);

        public static IRestResponse CharactersGet()
        {
            var client = new RestClient("https://gateway.marvel.com:443/v1/public");
            var request = new RestRequest($"/characters?orderBy=name&ts={ts}&apikey={apiKey}&hash={hash}", Method.GET) { RequestFormat = DataFormat.Json };
            return client.Execute(request);
        }
        public static IRestResponse CharactersGet(int limit, int offset){

            var client = new RestClient("https://gateway.marvel.com:443/v1/public");
            var request = new RestRequest($"/characters?orderBy=name&ts={ts}&apikey={apiKey}&hash={hash}", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("limit", limit);
            request.AddParameter("offset", offset);
            return client.Execute(request);
        }

        public static IRestResponse ComicsGet(int id)
        {
            var client = new RestClient("https://gateway.marvel.com:443/v1/public");
            var request = new RestRequest($"/characters/{id}/comics?format=comic&formatType=comic&orderBy=onsaleDate&ts={ts}&apikey={apiKey}&hash={hash}", Method.GET) { RequestFormat = DataFormat.Json };
            return client.Execute(request);
        }
        public static IRestResponse ComicsGet(int limit, int offset, int id)
        {

            var client = new RestClient("https://gateway.marvel.com:443/v1/public");
            var request = new RestRequest($"/characters/{id}/comics?format=comic&formatType=comic&orderBy=onsaleDate&ts={ts}&apikey={apiKey}&hash={hash}", Method.GET) { RequestFormat = DataFormat.Json };
            request.AddParameter("limit", limit);
            request.AddParameter("offset", offset);
            return client.Execute(request);
        }

    }
}
