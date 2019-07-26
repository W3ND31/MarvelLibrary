using MarvelLibrary.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelLibrary.Data;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace MarvelLibrary.Services
{
    public class CharacterService
    {
        private MarvelLibraryContext _context;

        public CharacterService(MarvelLibraryContext context)
        {
            _context = context;
        }
        public void InitCharacters()
        {

            dynamic jResult = JObject.Parse(RestServices.CharactersGet().Content);
            int total = jResult.data.total;
            int n = 0;

            //int count = _context.Character.Count();

            while (n < total)
            {

                //Objeto dinamico recebendo o conteúdo retornado do GET
                dynamic jResult2 = JObject.Parse(RestServices.CharactersGet(100, n).Content);

                //Extraindo apenas o conjunto de dados que importam pra minha aplicação
                var res = jResult2.data.results;

                //Iterando nos dados e inserindo no banco
                foreach (var x in res)
                {
                    //Se o id já existir no banco, não será inserido
                    if (_context.Character.Find((int)x.id) == null)
                    {
                        Character d = new Character((int)x.id, (string)x.name, (string)x.description, (DateTime)x.modified, (string)x.thumbnail.path + '.' + (string)x.thumbnail.extension);
                        _context.Add(d);
                        _context.SaveChanges();
                    }

                }
                n += 100;
            }
        }
        public IPagedList<Character> GetCharacters(int pagina)
        {
            return _context.Character.OrderBy(e => e.Name).ToPagedList(pagina, 100);
        }

        public IPagedList<Character> GetCharacters(string searchString, int pagina)
        {
            return _context.Character.Where(s => s.Name.Contains(searchString)).OrderBy(e => e.Name).ToPagedList(pagina, 100);
        }

        public async Task<IEnumerable<Character>> FavCharacters(){
            var _fav = _context.Fav.Select(e => e.CharacterId).ToList();
            return await (from p in _context.Character where _fav.Contains(p.Id) select p).OrderBy(e => e.Name).ToListAsync();
        }
    }
}
