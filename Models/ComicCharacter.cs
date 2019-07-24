using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelLibrary.Models
{
    public class ComicCharacter
    {
        public int ComicId { get; set; }
        public int CharacterId { get; set; }

        public ComicCharacter()
        {
        }

        public ComicCharacter(int comicId, int characterId)
        {
            ComicId = comicId;
            CharacterId = characterId;
        }
    }
}
