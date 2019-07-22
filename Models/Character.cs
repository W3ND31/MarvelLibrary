using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvelLibrary.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime Modified { get; set; }
        public string Thumbnail { get; set; }

        public Character()
        {
        }

        public Character(int id, string name, string desc, DateTime modified, string thumbnail)
        {
            Id = id;
            Name = name;
            Desc = desc;
            Modified = modified;
            Thumbnail = thumbnail;
        }
    }
}
