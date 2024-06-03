using System.Text.Json.Nodes;
using System.Text.Json;
using TallerPokemon.Models;

namespace TallerPokemon.Services
{
    public class PokemonSer : PokemonServices
    {
        private string urlApi = "https://pokeapi.co/api/v2/pokemon/?limit=100&offset=20";

        public async Task<List<PokemonItem>> Obtener()
        {
            var cliente = new HttpClient();
            var response = await cliente.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);
            JsonNode results = nodos["results"];

            var pokemonsData = JsonSerializer.Deserialize<List<PokemonItem>>(results.ToString());

            var tasks = pokemonsData.Select(async pokemon =>
            {
                var pokemonResponse = await cliente.GetAsync(pokemon.url);
                var pokemonBody = await pokemonResponse.Content.ReadAsStringAsync();
                JsonNode pokemonNode = JsonNode.Parse(pokemonBody);

             
                string imageUrl = pokemonNode["sprites"]["front_default"]?.ToString();
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    pokemon.ImageUrl = imageUrl;
                }

       
                var types = pokemonNode["types"].AsArray();
                var typeList = types.Select(typeNode => typeNode["type"]["name"].ToString()).ToList();
                pokemon.Type = string.Join(", ", typeList);

                var abilities = pokemonNode["abilities"].AsArray();
                var abilityList = abilities.Select(abilityNode => abilityNode["ability"]["name"].ToString()).ToList();
                pokemon.Abilities = abilityList;
            });

            await Task.WhenAll(tasks);

            return pokemonsData;
        }
    }
}