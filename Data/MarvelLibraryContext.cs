using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarvelLibrary.Models
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


        }

        public DbSet<Character> Character { get; set; }

        public DbSet<Fav> Fav { get; set; }
    }
}
