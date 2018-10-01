using System;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon pikachu = new Pokemon("Pikachu", 1000, 10);
            Pokemon dude = new Pokemon("Dude", 9003, 10);
            pikachu.Attack(ref dude);
            if (Battle.Prompt())
            {
                Battle.Fight(ref pikachu, ref dude);
            }


        }

    }   
}