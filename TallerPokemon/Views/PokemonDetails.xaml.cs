using Microsoft.Maui.Controls;
using TallerPokemon.Models;

namespace TallerPokemon.Views
{
    public partial class PokemonDetails : ContentPage
    {
        public PokemonDetails(PokemonItem pokemon)
        {
            InitializeComponent();
            BindingContext = pokemon;
        }
    }
}