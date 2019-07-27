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
        public bool FavExists(int id, string login)
        {
            return _context.Fav.Any(e => e.CharacterId == id && e.AccountLogin == login);
        }

        public void InsertFav(int id, string login)
        {
            if (!FavExists(id,login))
            {
                Fav f = new Fav(id, login);
                _context.Fav.Add(f);
                _context.SaveChanges();
            }
        }

        public void RemoveFav(int id,string login)
        {
            if (FavExists(id,login))
            {
                //List<Fav> list = _context.Fav.Where(e => e.CharacterId == id).ToList();
                Fav fav = new Fav();
                fav = _context.Fav.Find(id, login);
                _context.Fav.Remove(fav);
                _context.SaveChanges();
            }
        }
    }
}
