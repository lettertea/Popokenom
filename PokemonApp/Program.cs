using System;
using System.Collections.Generic;

namespace PokemonApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PokemonTrainer userTrainer = new PokemonTrainer(GetUserName());
            IntroduceGame(userTrainer);
            GetStarterPokemon(userTrainer);
            userTrainer.CaptivePokemons.Add(new Pokemon("Hia", 32));
            List<string> menuChoices = new List<string> { "Fight wild Pokemons", "Challenge Rival", "Shop", "Heal", "Save" };
            int userInput = Menu.GetUserInputIndex(menuChoices, false);
            switch (userInput)
            {
                case 0:
                    Menu.FightWildPokemon(userTrainer);
                    break;

            }

        }

        private static string GetUserName()
        {
            Console.WriteLine("Hi, what's your name?");
            return Console.ReadLine();
        }

        private static void IntroduceGame(PokemonTrainer userTrainer) {
            Console.WriteLine($"Hello there, {userTrainer.Name}! My name is not Nashkenazy, and this game might be called Popokénom.");
            Console.WriteLine("You'll notice that I put very little effort in making this game good.");
            Console.WriteLine("A Magikarp can be much stronger than Mew.");
            Console.WriteLine("In fact, it is the strongest Popokénom in this game.");
            Console.WriteLine("With that said, have fun!");
            Console.WriteLine();
        }

        private static void GetStarterPokemon(PokemonTrainer userTrainer)
        {
            Console.WriteLine("Choose your starter popokénom!");
            Console.WriteLine();
            List<string> starterPokemons = new List<string> { "Bulbasaur", "Charmander", "Squirtle" };
            int userInputIndex = Menu.GetUserInputIndex(starterPokemons, false);
            string pokemonChosen = starterPokemons[userInputIndex];
            userTrainer.CaptivePokemons.Add(new Pokemon(pokemonChosen, 1));
            Console.WriteLine($"Congratulations! {pokemonChosen} joined your party.");
        }
    }   
}