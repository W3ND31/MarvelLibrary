using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelLibrary.Models.ViewModels
{
    public class FavCharactersViewModel
    {
        public Fav Fav { get; set; }
        public IEnumerable<Character> Characters { get; set; }
        
    }
}
