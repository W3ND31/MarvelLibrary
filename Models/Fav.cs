using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelLibrary.Models
{
    public class Fav
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CharacterId { get; set; }

        public Fav()
        {
        }

        public Fav(int characterId)
        {
            CharacterId = characterId;
        }

       
    }
}
