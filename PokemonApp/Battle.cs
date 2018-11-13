using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace PokemonApp
{
    class Battle
    {

        public static void FightPokemon(PokemonTrainer userTrainer, Pokemon opponent)
        {
            Pokemon userPokemon = userTrainer.CaptivePokemons[0];

            List<string> menuChoices = new List<string> { "Attack", "Change Popokenom", "Item", "Run" };
            while (opponent.Hp > 0 && !userTrainer.AllPokemonsFainted())
            {
                if (userPokemon.Hp <= 0) { ChangePokemon(userPokemon, userTrainer); }

                int userInputIndex = Menu.GetUserInputIndex(menuChoices, false);
                switch (userInputIndex)
                {
                    case 0:
                        Attack(userPokemon, opponent);
                        break;
                    case 1:
                        ChangePokemon(userPokemon, userTrainer);
                        OpponentMightAttack(userPokemon, opponent);
                        break;
                    case 2:
                        InteractWithItems(userPokemon, userTrainer, opponent);
                        break;
                    case 3:
                        if (Run(userPokemon, opponent)) { return; };
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


                }

        public static void Attack(ref Pokemon userPokemon, ref Pokemon opponent)
        {
            userPokemon.Attack(opponent);
            Console.WriteLine($"{opponent.Name} Hp drops to {opponent.Hp}.");
            if (opponent.Hp <= 0) { return; }
            opponent.Attack(userPokemon);
            Console.WriteLine($"{userPokemon.Name} Hp drops to {userPokemon.Hp}.");
        }

        public static void OpponentMightAttack(Pokemon userPokemon, Pokemon opponent)
        {
            Random rand = new Random();
            if (rand.Next(0, 2) == 0)
            {
                Console.WriteLine($"{opponent.Name} waits for you to get ready.");
            }
            else
            {
                Console.WriteLine($"{opponent.Name} doesn't care and attacks!");
                opponent.Attack(userPokemon);
                Console.WriteLine($"{userPokemon.Name} Hp lowers to {userPokemon.Hp}.");
            }
        }

        public static void ChangePokemon(Pokemon userPokemon, PokemonTrainer userTrainer)
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
        }

        public static void InteractWithItems(Pokemon userPokemon, PokemonTrainer userTrainer, Pokemon opponent)
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
            if (itemChosen.PokemonAffected == "user") { userTrainer.Items[userInputIndex].Use(userPokemon, userTrainer); }
            else { userTrainer.Items[userInputIndex].Use(opponent, userTrainer); }

            OpponentMightAttack(userPokemon, opponent);

        }
        public static bool Run(Pokemon userPokemon, Pokemon opponent)
        {
            if (userPokemon.Hp >= opponent.Hp)
            {
                Console.WriteLine($"{userPokemon.Name} fled the scene.");
                return true;
            }
            Console.WriteLine($"{opponent.Name} stops you.");
            OpponentMightAttack(userPokemon, opponent);
            return false;
        }

    }
}
