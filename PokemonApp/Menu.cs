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
                if (cancel) { options.Add("Cancel"); }
                for (int i = 0; i < options.Count; i++)
                {
                    string option = options[i];
                    Console.WriteLine($"{i + 1}. {option}");
                }

                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    userInputIndex = userInput - 1;
                    if (userInputIndex >= 0 && userInputIndex < options.Count)
                    {
                        if (cancel && userInputIndex == options.Count - 1) { return -1; }
                        return userInputIndex;
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
