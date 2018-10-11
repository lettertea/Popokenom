using System;
using System.Collections.Generic;
using System.Text;


namespace PokemonApp
{
    class Battle
    {

        public static void Fight(ref List<Pokemon> userPokemons, ref Pokemon opponent)
        {
            Pokemon player = userPokemons[0];
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
                Console.WriteLine($"{player.Name} gained {player.GainExp(opponent)} EXP!");
            }
        }

    }
}
