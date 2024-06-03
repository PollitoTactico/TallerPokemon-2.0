using Microsoft.Maui.Controls;
using TallerPokemon.Views;
using TallerPokemon.Services;

namespace TallerPokemon
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var pokemonService = new PokemonSer();

            MainPage = new AppShell();
        }
    }
}
