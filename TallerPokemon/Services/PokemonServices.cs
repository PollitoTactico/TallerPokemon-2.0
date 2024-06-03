
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerPokemon;
using TallerPokemon.Models;

namespace TallerPokemon.Services
{
    public interface PokemonServices
    {
        public Task<List<PokemonItem>> Obtener();
        


    }
}
