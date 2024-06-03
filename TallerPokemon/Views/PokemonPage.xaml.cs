using TallerPokemon.Services;
using TallerPokemon.Models;
namespace TallerPokemon.Views;


public partial class PokemonPage : ContentPage
{
	private readonly PokemonServices _pokemonServices;
	public PokemonPage(PokemonServices service)
	{
		InitializeComponent();
		_pokemonServices = service;
	}
	private async void Pokedex_Clicked (object sender, EventArgs e)
    {

		papu.IsVisible = true;
		var data = await _pokemonServices.Obtener();	
		Pokemons.ItemsSource = data;
		papu.IsVisible = false;

    }
    private async void Pokemons_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is PokemonItem pokemon)
        {
            
            await Navigation.PushAsync(new PokemonDetails(pokemon));
        }
    }
}