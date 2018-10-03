using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Battle
    {
        public static bool Prompt()
        {
            ConsoleKey response;
            do
            {
                Console.Write("Fight? [y/n] ");
                response = Console.ReadKey(false).Key;

            } while (response != ConsoleKey.Y && response != ConsoleKey.N);
            if (response == ConsoleKey.Y)
            {
                return true;
            }
            else { Console.WriteLine("Have a good day!"); return false; }

        }
        public static void Fight(ref Pokemon player, ref Pokemon opponent)
        {
            while (player.Hp > 0 && opponent.Hp > 0)
            {
                player.Attack(ref opponent);
                opponent.Attack(ref player);
                Console.WriteLine();
                Console.WriteLine(player.Hp);
                Console.WriteLine(opponent.Hp);
            }
            if (player.Hp <= 0)
            {
                Console.WriteLine($"{player.Name} fainted.");
            }
            else
            {
                Console.WriteLine($"{opponent.Name} fainted.");
                player.Exp += opponent.ExpReleased;
                Console.WriteLine($"{player.Name} gained {opponent.ExpReleased} EXP!");
            }
        }

    }
}
