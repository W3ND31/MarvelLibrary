using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarvelLibrary.Services;
using MarvelLibrary.Data;

namespace MarvelLibrary.Controllers
{
    public class CharactersController : Controller
    {
        private readonly MarvelLibraryContext _context;
        private readonly CharacterService _charService;
        private readonly FavService _favService;

        public CharactersController(MarvelLibraryContext context, CharacterService charService, FavService favService)
        {
            _context = context;
            _charService = charService;
            _favService = favService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Character.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .FirstOrDefaultAsync(m => m.Id == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        public IActionResult Create()
        {

            _charService.InitCharacters();
            return Redirect("Index");
        }

        public IActionResult Fav(int id)
        {
            _favService.InsertFav((int)id);
            return RedirectToAction(nameof(Index));

        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.Id == id);
        }
    }
}
