﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarvelLibrary.Data;
using MarvelLibrary.Models;
using MarvelLibrary.Services;

namespace MarvelLibrary.Controllers
{
    public class FavsController : Controller
    {
        private readonly MarvelLibraryContext _context;
        private readonly CharacterService _charService;
        private readonly FavService _favService;
        private readonly ComicService _comicService;

        public FavsController(MarvelLibraryContext context, CharacterService charService, FavService favService, ComicService comicService)
        {
            _context = context;
            _charService = charService;
            _favService = favService;
            _comicService = comicService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _charService.FavCharacters());
        }

        public IActionResult Comics(int id)
        {
            int n = id;
            _comicService.InsertComics(id);
            return RedirectToAction(nameof(Details), new { id = n });
        }

        public async Task<IActionResult> Details(int? id, string searchString)
        {
            ViewData["Filter"] = searchString;
            ViewBag.id = id;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (id == null)
                {
                    return NotFound();
                }
                _comicService.InsertComics((int)id);

                var comics = await _comicService.GetComics((int)id, searchString);

                int n = comics.Count();
                if (n == 0)
                {
                    return NotFound();
                }

                return View(await _comicService.GetComics((int)id,searchString));
            }
            else
            {
                if (id == null)
                {
                    return NotFound();
                }
                _comicService.InsertComics((int)id);

                var comics = await _comicService.GetComics((int)id);

                int n = comics.Count();
                if (n == 0)
                {
                    return NotFound();
                }

                return View(await _comicService.GetComics((int)id));
            }
        }

        private bool FavExists(int id)
        {
            return _context.Fav.Any(e => e.Id == id);
        }
    }
}
