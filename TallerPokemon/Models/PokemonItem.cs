using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerPokemon.Models
{
    public class PokemonItem
    {

        public string name { get; set; }
        public string url { get; set; }
        public string ImageUrl {get; set;}
        public string Type { get; set; } 
        public List<string> Abilities { get; set; } 
    }
}
