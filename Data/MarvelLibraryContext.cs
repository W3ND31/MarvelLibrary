using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MarvelLibrary.Models;
using MarvelLibrary.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata;

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
            builder.Entity<Fav>().HasKey(table => new { table.CharacterId,table.AccountLogin});
            builder.Entity<Character>().Property(m => m.Id).ValueGeneratedNever();
            builder.Entity<Comic>().Property(m => m.Id).ValueGeneratedNever();
            builder.Entity<ComicCharacter>().HasKey(table => new { table.ComicId, table.CharacterId });
            builder.Entity<Account>().HasKey(table => new { table.Login });

        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Fav> Fav { get; set; }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<ComicCharacter> ComicCharacter { get; set; }
        public DbSet<Account> Account { get; set; }
    }
}
