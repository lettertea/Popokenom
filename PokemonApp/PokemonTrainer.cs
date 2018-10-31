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
            Console.WriteLine("Choose your starter pokemon!");
            List<string> pokemonChoices = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                string randomPokemon = Pokemons.GetRandomPokemon();
                pokemonChoices.Add(randomPokemon);
            }
            int userInputIndex = Menu.GetUserInputIndex(pokemonChoices.ToArray());
            string pokemonChosen = pokemonChoices[userInputIndex];
            this.CaptivePokemons.Add(new Pokemon(pokemonChosen, 1));
            Console.WriteLine($"Congratulations! {pokemonChosen} joined your party.");
        }

    }


}
