using System;
using System.Collections.Generic;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonTrainer user = new PokemonTrainer();
            user.Items.Add(PokeballStore.GetUltraball());
            user.GetStarterPokemon();
            user.CaptivePokemons.Add(new Pokemon("Hia", 32));
            List<string> menuChoices = new List<string> { "Fight wild Pokemons", "Challenge gym leaders", "Shop", "Heal", "Save" };
            int userInput = Menu.GetUserInputIndex(menuChoices, false);
            switch (userInput)
            {
                case 0:
                    Menu.FightWildPokemon(ref user);
                    break;
            }

        }
    }   
}