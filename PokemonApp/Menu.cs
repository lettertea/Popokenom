using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Menu
    {
        public static int GetUserInputIndex(List<string> options, bool cancel)
        {
            int userInputIndex;
            do
            {
                int i;
                for (i = 0; i < options.Count; i++)
                {
                    string option = options[i];
                    Console.WriteLine($"{i + 1}. {option}");
                }

                int cancelIndex = -1;
                if (cancel)
                { 
                cancelIndex = i;
                options.Add($"{cancelIndex + 1}. Cancel");
                }

                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    userInputIndex = userInput - 1;
                    if (userInputIndex >= 0 && userInput < options.Count)
                    {
                        return userInputIndex == cancelIndex ? -1 : userInputIndex;
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
                        Pokemon opponent = new Pokemon(PokemonStore.GetRandomPokemon(), opponentLevel);
                        Console.WriteLine($"A wild {opponent.Name} appeared.");
                        Battle.Fight(ref userPokemons, ref opponent);
                        break;
                    }
                }
            } while (true);
        }

    }
}
