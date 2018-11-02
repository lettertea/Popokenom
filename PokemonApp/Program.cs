using System;
using System.Collections.Generic;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IntroduceGame();
            PokemonTrainer user = new PokemonTrainer();
            user.Items.Add(PotionStore.GetPotion());
            user.GetStarterPokemon();
            user.CaptivePokemons.Add(new Pokemon("Hia", 32));
            List<string> menuChoices = new List<string> { "Fight wild Pokemons", "Challenge gym leaders", "Shop", "Heal", "Save" };
            int userInput = Menu.GetUserInputIndex(menuChoices, false);
            switch (userInput)
            {
                case 0:
                    Menu.FightWildPokemon(ref user);
                    break;
            }

        }

        static void IntroduceGame() {
            Console.WriteLine("Hello there! My name is not Nashkenazy, and this game might be called Popokénom.");
            Console.WriteLine("You'll notice that I put very little effort in making this game good.");
            Console.WriteLine("A Magikarp can be much stronger than Mew.");
            Console.WriteLine("In fact, it is the strongest Popokénom in this game.");
            Console.WriteLine("With that said, have fun!");
            Console.WriteLine();
        }
    }   
}