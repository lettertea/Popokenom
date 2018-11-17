using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

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

        public static void FightWildPokemon(PokemonTrainer userTrainer)
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
                        Console.WriteLine($"A wild {opponent.Name} (R:{opponent.Rarity}) appeared.");
                        Console.WriteLine($"{userTrainer.Name}: Alright, let's show 'em what we got, {userTrainer.PokemonOut.Name} (R:{userTrainer.PokemonOut.Rarity})");
                        Battle.FightPokemon(userTrainer, opponent);
                        break;
                    }
                }
            } while (true);
        }

        public static void ChallengeRival(PokemonTrainer userTrainer)
        {
            List<string> userChoices = new List<string>();

            for (int i = 1; i < 11; i++)
            {
                double timePassed = .25 * Math.Pow(i, 1.9);
                int yearsPassed = (int)timePassed;
                int remainingMonths = (int)((timePassed - yearsPassed) * 12);
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(remainingMonths + 1);

                userChoices.Add($"Bary Yoke in {monthName}, {2000 + yearsPassed}");
            }

            int userInputIndex = Menu.GetUserInputIndex(userChoices, true);
            if (userInputIndex == -1) { return; }

            RivalTrainer rival = new RivalTrainer("Bary Yoke", userInputIndex + 1);
            rival.SetPokemons(userTrainer.StarterPokemon);
            rival.Introduction(userTrainer);
            Battle.FightTrainer(userTrainer, rival);
        }
        public static void PurchaseItem(PokemonTrainer userTrainer)
        {
            Console.WriteLine($"Money: {userTrainer.Money}");
            List<string> itemChoices = new List<string>();
            Console.WriteLine("----------------------");
            Console.WriteLine("Price   |   Name");
            Console.WriteLine("----------------------");

            foreach (IItem item in ItemStore.Items)
            {
                itemChoices.Add(String.Format("{0,-4} | {1,-4}", item.Price, item.Name));
            }
            int userInputIndex = Menu.GetUserInputIndex(itemChoices, true);

            if (userInputIndex == -1) { return; }
            ItemStore.PurchaseItem(userTrainer, userInputIndex);

        }

        public static void Save(PokemonTrainer userTrainer)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + @"\saves.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, userTrainer);
            stream.Close();
        }

        public static PokemonTrainer Load()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(System.AppDomain.CurrentDomain.BaseDirectory + @"\saves.bin", FileMode.Open, FileAccess.Read);
            PokemonTrainer userTrainer = (PokemonTrainer)formatter.Deserialize(stream);
            stream.Close();
            return userTrainer;
        }
    }
}
