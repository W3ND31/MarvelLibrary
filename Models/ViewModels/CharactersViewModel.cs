using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelLibrary.Models.ViewModels
{
    public class CharactersViewModel
    {
        public ICollection<Character> Characters { get; set; }
        public Fav Fav { get; set; }
    }
}
