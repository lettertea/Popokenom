using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace PokemonApp
{
    class Menu
    {
        public static int GetUserInputIndex(List<string> options, bool cancel)
        {
            if (cancel) { options.Add("Cancel"); }
            do
            {
                for (int i = 0; i < options.Count; i++)
                {
                    string option = options[i];
                    Console.WriteLine($"{i + 1}. {option}");
                }

                if (int.TryParse(Console.ReadLine(), out int userInput))
                {
                    int userInputIndex = userInput - 1;
                    if (userInputIndex >= 0 && userInputIndex < options.Count)
                    {
                        if (cancel && userInputIndex == options.Count - 1) { return -1; }
                        return userInputIndex;
                    }
                    Console.WriteLine("Try again");
                }
            } while (true);
        }

        public static void FightWildPokemon(PokemonTrainer userPokemons)
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

        public static void ChallengeRival(PokemonTrainer userTrainer)
        {
            PokemonTrainer rival = new PokemonTrainer("Bary");
            List<string> userChoices = new List<string>();

            for (int i = 1; i < 11; i++)
            {
                double timePassed = .25 * Math.Pow(i, 1.9);
                int yearsPassed = (int)timePassed;
                int remainingMonths = (int)((timePassed - yearsPassed)*12);
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(remainingMonths+1);

                userChoices.Add($"Bary Yoke of {monthName} in the year {2000 + yearsPassed}");
            }

            int userInputIndex = Menu.GetUserInputIndex(userChoices, true);

            if (userInputIndex == -1) { return; }

        }

    }
}
