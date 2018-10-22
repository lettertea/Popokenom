using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Menu
    {
        public static int GetUserInputIndex(string[] options)
        {
            int userInputIndex;
            do
            {
                for (int i = 0; i < options.Length; i++)
                {
                    string option = options[i];
                    Console.WriteLine($"{i + 1}. {option}");
                }

                if (int.TryParse(Console.ReadLine(), out userInputIndex))
                {
                    if (userInputIndex >= 1 && userInputIndex <= options.Length)
                    {
                        return userInputIndex-1;
                    }
                    Console.WriteLine("Try again");
                }
            } while (true);
        }

        public static void FightWildPokemon(ref PokemonTrainer userPokemons)
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
