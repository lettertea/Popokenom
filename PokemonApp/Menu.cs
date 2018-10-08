using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Menu
    {
        public void PromptChoices()
        {
            Console.WriteLine("1. Fight wild Pokemons.");
            if (int.TryParse(Console.ReadLine(), out int menuChoice))
            {
                switch (menuChoice)
                { case 1:
                        Console.WriteLine("What level? [1-100]");
                        if (int.TryParse(Console.ReadLine(), out int opponentLevel))
                        {
                            Pokemon opponent = new Pokemon(Pokemons.GetRandomPokemon(), opponentLevel);
                        }
                            break;


                }

            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}
