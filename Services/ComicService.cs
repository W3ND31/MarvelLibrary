using MarvelLibrary.Data;
using MarvelLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelLibrary.Services
{
    public class ComicService
    {
        private MarvelLibraryContext _context;

        public ComicService(MarvelLibraryContext context)
        {
            _context = context;
        }
        public void InsertComics(int id)
        {

            dynamic jResult =  JObject.Parse(RestServices.ComicsGet(id).Content);
            int total = jResult.data.total;
            int comics = _context.ComicCharacter.Count(e => e.CharacterId == id);
            int n = 0;

            if (comics < total)
            {
                while (n < total)
                {

                    //Objeto dinamico recebendo o conteúdo retornado do GET
                    dynamic jResult2 = JObject.Parse(RestServices.ComicsGet(100, n, id).Content);

                    //Extraindo apenas o conjunto de dados que importam pra minha aplicação
                    var res = jResult2.data.results;

                    //Iterando nos dados e inserindo no banco
                    foreach (var x in res)
                    {
                        //Se o id já existir no banco, não será inserido
                        if (_context.Comic.Find((int)x.id) == null)
                        {
                            //(string)x.description, (DateTime)x.modified, (string)x.thumbnail.path + '.' + (string)x.thumbnail.extension
                            DateTime date = DateTime.Now;
                            foreach (var t in x.dates)
                            {
                                if (t.type == "onsaleDate")
                                {
                                    bool z = DateTime.TryParse((string)t.date, out date);

                                    if (z)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        date = DateTime.Now;
                                    }


                                }
                            }

                            Comic d = new Comic((int)x.id, (string)x.title, (string)x.format, (int)x.pageCount, (string)x.series.name, (DateTime)date, (string)x.thumbnail.path + '.' + (string)x.thumbnail.extension, (string)x.description);
                            _context.Add(d);
                            _context.SaveChanges();

                            var c = x.characters.items;
                            foreach (var h in c)
                            {
                                string s = h.resourceURI;
                                int last = s.LastIndexOf('/');
                                s = s.Substring(last + 1);
                                ComicCharacter e = new ComicCharacter((int)x.id, int.Parse(s));
                                _context.Add(e);
                                _context.SaveChanges();
                            }
                        }

                    }
                    n += 100;
                }
            }
        }

        public async Task<IEnumerable<Comic>> GetComics(int id)
        {
            var comicsForId = await (from p in _context.ComicCharacter where p.CharacterId == id select p.ComicId).ToListAsync();
            return await (from p in _context.Comic where comicsForId.Contains(p.Id) select p).OrderBy(e => e.OnSaleDate).ToListAsync();
        }
        public async Task<IEnumerable<Comic>> GetComics(int id,string searchString)
        {
            var comicsForId = await (from p in _context.ComicCharacter where p.CharacterId == id select p.ComicId).ToListAsync();
            return await (from p in _context.Comic where comicsForId.Contains(p.Id) && p.Title.Contains(searchString) select p).OrderBy(e => e.OnSaleDate).ToListAsync();
        }
    }
}
