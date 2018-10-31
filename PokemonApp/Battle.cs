using System;
using System.Collections.Generic;
using System.Text;


namespace PokemonApp
{
    class Battle
    {

        public static void Fight(ref PokemonTrainer userTrainer, ref Pokemon opponent)
        {
            Pokemon userPokemon = userTrainer.CaptivePokemons[0];
            List<string> menuChoices = new List<string> { "Attack", "Change Popokenom", "Item", "Run" };
            while (userPokemon.Hp > 0 && opponent.Hp > 0)
            {
                int userInputIndex = Menu.GetUserInputIndex(menuChoices, false);
                switch (userInputIndex)
                {
                    case 0:
                        Attack(ref userPokemon, ref opponent);
                        break;

                    case 1:
                        ChangePokemon(ref userPokemon, ref userTrainer, ref opponent);
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
        public static void ChangePokemon(ref Pokemon userPokemon, ref PokemonTrainer userTrainer, ref Pokemon opponent)
        {
            List<string> userChoices = new List<string>();
            for (int i = 1; i < userTrainer.CaptivePokemons.Count; i++)
            {
                Pokemon pokemon = userTrainer.CaptivePokemons[i];
                userChoices.Add($"{pokemon.Name} - Level: {pokemon.Level}, Hp: {pokemon.Hp}");
            }

            int userInputIndex = Menu.GetUserInputIndex(userChoices, true);

            if (userInputIndex == -1) { return; }
            Console.WriteLine($"Come back {userPokemon.Name}.");

            userPokemon = userTrainer.CaptivePokemons[userInputIndex];
            Console.WriteLine($"I choose you, {userPokemon.Name}.");
            

            Random rand = new Random();
            if (rand.Next(0, 2) == 0) {
                Console.WriteLine($"{opponent.Name} waits for you to get ready.");
            }
            else {
                Console.WriteLine($"{opponent.Name} doesn't care and attacks!");
                opponent.Attack(ref userPokemon);
                Console.WriteLine($"{userPokemon.Name} Hp lowers to {userPokemon.Hp}.");
            }
        }
    }
}
