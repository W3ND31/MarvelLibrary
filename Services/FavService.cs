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
        public bool FavExists(int id)
        {
            return _context.Fav.Any(e => e.CharacterId == id);
        }

        public void InsertFav(int id)
        {
            if (!FavExists(id))
            {
                Fav f = new Fav((int)id);
                _context.Fav.Add(f);
                _context.SaveChanges();
            }
        }

        public void RemoveFav(int id)
        {
            if (FavExists(id))
            {
                List<Fav> list = _context.Fav.Where(e => e.CharacterId == id).ToList();
                Fav f = list[0];
                _context.Fav.Remove(f);
                _context.SaveChanges();
            }
        }
    }
}
