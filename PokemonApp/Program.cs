using System;
using System.Collections.Generic;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonTrainer user = new PokemonTrainer();
            user.GetStarterPokemon();
            user.CaptivePokemons.Add(new Pokemon("Hia", 32));
            string[] menuChoices = { "Fight wild Pokemons", "Challenge gym leaders", "Shop", "Heal", "Save" };
            int userInput = Menu.GetUserInputIndex(menuChoices);
            switch (userInput)
            {
                case 0:
                    Menu.FightWildPokemon(ref user);
                    break;
            }

        }








    }   
}