﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarvelLibrary.Models;
using MarvelLibrary.Models.ViewModels;

namespace MarvelLibrary.Data
{
    public class MarvelLibraryContext : DbContext
    {
        public MarvelLibraryContext(DbContextOptions<MarvelLibraryContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fav>().Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Entity<Fav>().HasKey(table => new { table.Id, table.CharacterId });

            builder.Entity<ComicCharacter>().HasKey(table => new { table.ComicId, table.CharacterId });

        }

        public DbSet<Character> Character { get; set; }

        public DbSet<Fav> Fav { get; set; }

        public DbSet<Comic> Comic { get; set; }

        public DbSet<ComicCharacter> ComicCharacter { get; set; }
    }
}
