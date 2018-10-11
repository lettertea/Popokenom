using System;
using System.Collections.Generic;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> userPokemons = new List<Pokemon> { new Pokemon("Mikachu", 78) };
            int userInput = Menu.PromptChoices();
            switch (userInput)
            {
                case 1:
                    Menu.FightWildPokemon(ref userPokemons);
                    break;
            }

        }





    }   
}