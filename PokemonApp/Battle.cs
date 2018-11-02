using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace PokemonApp
{
    class Battle
    {

        public static void Fight(ref PokemonTrainer userTrainer, ref Pokemon opponent)
        {
            Pokemon userPokemon = userTrainer.CaptivePokemons[0];
            List<string> menuChoices = new List<string> { "Attack", "Change Popokenom", "Item", "Run" };
            while (opponent.Hp > 0 && !PokemonTrainer.allPokemonsFainted(userTrainer))
            {
                if (userPokemon.Hp <= 0) { ChangePokemon(ref userPokemon, ref userTrainer, ref opponent); }

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
                        InteractWithItems(ref userPokemon, ref userTrainer, ref opponent);
                        break;



                }

            }
            if (opponent.Hp <= 0)
            {
                Console.WriteLine($"{opponent.Name} fainted.");
                Console.WriteLine($"{userPokemon.Name} gained {userPokemon.GainExp(opponent)} EXP!");
            }
            else
            {
                Console.WriteLine($"{userPokemon.Name} fainted.");
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

        public static void OpponentMightAttack(ref Pokemon userPokemon, ref Pokemon opponent)
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                Console.WriteLine($"{opponent.Name} waits for you to get ready.");
            }
            else
            {
                Console.WriteLine($"{opponent.Name} doesn't care and attacks!");
                opponent.Attack(ref userPokemon);
                Console.WriteLine($"{userPokemon.Name} Hp lowers to {userPokemon.Hp}.");
            }
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

            userTrainer.SwapPokemons(0, userInputIndex);
            userPokemon = userTrainer.CaptivePokemons[userInputIndex + 1]; // Add one because current pokemon on field is not counted.
            Console.WriteLine($"I choose you, {userPokemon.Name}.");

            OpponentMightAttack(ref userPokemon, ref opponent);
        }

        public static void InteractWithItems(ref Pokemon userPokemon, ref PokemonTrainer userTrainer, ref Pokemon opponent)
        {
            List<string> userItems = new List<string>();

            for (int i = 0; i < userTrainer.Items.Count; i++)
            {
                string itemName = userTrainer.Items[i].Name;
                userItems.Add($"{i + 1}. {itemName}");
            }
            int userInputIndex = Menu.GetUserInputIndex(userItems, true);

            if (userInputIndex == -1) { return; }
            Item itemChosen = userTrainer.Items[userInputIndex];
            if (itemChosen.PokemonAffected == "user") { userTrainer.Items[userInputIndex].Use(ref userPokemon, ref userTrainer); }
            else { userTrainer.Items[userInputIndex].Use(ref opponent, ref userTrainer); }

            OpponentMightAttack(ref userPokemon, ref opponent);

        }
    }
}
