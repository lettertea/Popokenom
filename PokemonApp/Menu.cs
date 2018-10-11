using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Menu
    {
        public static int PromptChoices()
        {
            int userInput;
            do
            {
                string[] options = { "Fight wild Pokemons", "Challenge gym leaders", "Shop", "Heal", "Save" };
                for (int i = 0; i < options.Length; i++)
                {
                    string option = options[i];
                    Console.WriteLine($"{i+1}. {option}");
                }

                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    if (userInput >= 1 && userInput <= options.Length) {
                        return userInput;
                    }
                }
            } while (true);
        }

        public static void FightWildPokemon(ref List<Pokemon> userPokemons)
        {
            int opponentLevel;
            do
            {
                Console.WriteLine("Your opponent level?");
                if (int.TryParse(Console.ReadLine(), out opponentLevel))
                {
                    if (opponentLevel >= 1 && opponentLevel <= 100)
                    {
                        Pokemon opponent = new Pokemon(Pokemons.GetRandomPokemon(), opponentLevel);
                        Battle.Fight(ref userPokemons, ref opponent);
                        break;
                    }
                }
            } while (true);
        }

    }
}
