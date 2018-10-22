using System;
using System.Collections.Generic;
using System.Text;


namespace PokemonApp
{
    class Battle
    {

        public static void Fight(ref PokemonTrainer userPokemons, ref Pokemon opponent)
        {
            Pokemon userPokemon = userPokemons.CaptivePokemons[0];
            string[] menuChoices = { "Attack", "Change Popokenom", "Item", "Run" };
            while (userPokemon.Hp > 0 && opponent.Hp > 0)
            {
                int userInputIndex = Menu.GetUserInputIndex(menuChoices);
                switch (userInputIndex)
                {
                    case 0:
                        Attack(ref userPokemon, ref opponent);
                        break;

                    case 1:
                        ChangePokemon(ref userPokemon, ref userPokemons, ref opponent);
                        break;
                    case 2:

                }

            }
            if (userPokemon.Hp <= 0)
            {
                Console.WriteLine($"{userPokemon.Name} fainted.");
            }
            else
            {
                Console.WriteLine($"{opponent.Name} fainted.");
                Console.WriteLine($"{userPokemon.Name} gained {userPokemon.GainExp(opponent)} EXP!");
            }
        }

        public static void Attack(ref Pokemon userPokemon, ref Pokemon opponent)
        {
            userPokemon.Attack(ref opponent);
            opponent.Attack(ref userPokemon);
            Console.WriteLine();
            Console.WriteLine(userPokemon.Hp);
            Console.WriteLine(opponent.Hp);
        }
        public static void ChangePokemon(ref Pokemon userPokemon, ref PokemonTrainer userPokemons, ref Pokemon opponent)
        {
            List<string> userChoices = new List<string>();
            int i;
            for (i = 0;  i < userPokemons.CaptivePokemons.Count; i++)
            {
                Pokemon pokemon = userPokemons.CaptivePokemons[i];
                userChoices.Add($"{i + 1}. {pokemon.Name} - Level: {pokemon.Level}, Hp: {pokemon.Hp}");
            }
            int cancelIndex = i;
            userChoices.Add($"{cancelIndex + 1}. Cancel");
            int userInputIndex = Menu.GetUserInputIndex(userChoices.ToArray());

            if (userInputIndex == i) { return; }
            Console.WriteLine($"Come back {userPokemon.Name}.");
            if (userPokemon == userPokemons.CaptivePokemons[userInputIndex])
            {
                Console.WriteLine($"Wait—I didn't mean that. Get back out there, {userPokemon.Name}");
            } else { 
            userPokemon = userPokemons.CaptivePokemons[userInputIndex];
            Console.WriteLine($"I choose you, {userPokemon.Name}.");
            }
            Random rand = new Random();
            if (rand.Next(0, 2) == 0) {
                Console.WriteLine($"{opponent.Name} waits for you to get ready.");
            }
            else {
                Console.WriteLine($"{opponent.Name} doesn't care and attacks!");
                opponent.Attack(ref userPokemon);
                Console.WriteLine($"{opponent.Name} is now at {userPokemon.Hp} Hp.");
            }
        }
    }
}
