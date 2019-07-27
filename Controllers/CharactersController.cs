using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarvelLibrary.Services;
using MarvelLibrary.Data;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace MarvelLibrary.Controllers
{
    [Authorize]
    public class CharactersController : Controller
    {
        private readonly MarvelLibraryContext _context;
        private readonly CharacterService _charService;
        private readonly FavService _favService;
        private readonly AccountService _accountService;

        public CharactersController(MarvelLibraryContext context, CharacterService charService, FavService favService, AccountService accountService)
        {
            _context = context;
            _charService = charService;
            _favService = favService;
            _accountService = accountService;
        }

        public IActionResult Index(string searchString, int pagina)
        {
            if(pagina == 0)
            {
                pagina = 1;
            }
            ViewBag.pagina = pagina;
            ViewData["Filter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                return View(_charService.GetCharacters(searchString,pagina));
            }
            else
            {
                return View(_charService.GetCharacters(pagina));
            }
        }

        public async Task<IActionResult> Details(int? id, string searchString, int? pagina)
        {

            if (pagina == null)
            {
                pagina = 1;
            }

            ViewBag.pagina = pagina;
            ViewBag.searchString = searchString;

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);

            bool teste = _favService.FavExists((int)id,_accountService.GetUserLogged());
            if (teste)
            {
                ViewBag.Fav = "Remove Favorite";
            }
            else
            {
                ViewBag.Fav = "Set Favorite";
            }
            
            return View(character);
        }

        public IActionResult Create()
        {
           
            _charService.InitCharacters();
            return Redirect("Index");
        }

        public IActionResult Favorite(int id,string searchString, int? pagina)
        {
            if (_favService.FavExists(id, _accountService.GetUserLogged()))
            {
                _favService.RemoveFav(id, _accountService.GetUserLogged());
            }else
            {
                _favService.InsertFav(id, _accountService.GetUserLogged());
            }
            int n = id;
            string s = searchString;
            int p = (int)pagina;
            return RedirectToAction(nameof(Details), new { id = n, searchString = s, pagina = p});

        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.Id == id);
        }
    }
}
