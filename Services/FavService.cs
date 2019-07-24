using MarvelLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarvelLibrary.Data;

namespace MarvelLibrary.Services
{
    public class FavService
    {
        private MarvelLibraryContext _context;

        public FavService(MarvelLibraryContext context)
        {
            _context = context;
        }

        public void InsertFav(int id)
        {
            var ch = _context.Character.Find(id);

            bool teste = _context.Fav.Any((e) => e.CharacterId == id);

            if (!teste)
            {
                Fav f = new Fav((int)id, ch);
                _context.Fav.Add(f);
                _context.SaveChanges();
            }
        }
    }
}
