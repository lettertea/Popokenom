using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class PokemonTrainer
    {

        public List<Pokemon> CaptivePokemons { get; } = new List<Pokemon>();


        public int Money { get; set; }
        public int MoneyDropped { get; set; }
        public List<Item> Items { get; } = new List<Item>();


        public void GetStarterPokemon()
        {
            Console.WriteLine("Choose your starter popokénom!");
            Console.WriteLine();
            List<string> starterPokemons = new List<string> { "Bulbasaur", "Charmander", "Squirtle" };
            int userInputIndex = Menu.GetUserInputIndex(starterPokemons, false);
            string pokemonChosen = starterPokemons[userInputIndex];
            this.CaptivePokemons.Add(new Pokemon(pokemonChosen, 1));
            Console.WriteLine($"Congratulations! {pokemonChosen} joined your party.");
        }

    }


}
