using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MarvelLibrary.Models
{
    public class MarvelLibraryContext : DbContext
    {
        public MarvelLibraryContext (DbContextOptions<MarvelLibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Character> Character { get; set; }
    }
}
