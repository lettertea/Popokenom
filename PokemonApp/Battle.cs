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

            List<string> menuChoices = new List<string> { "Attack", "Change Popokenom", "Item", "Run" };
            while (opponent.Hp > 0 && !userTrainer.AllPokemonsFainted())
            {
                if (userTrainer.PokemonOut.Hp == 0) { ChangePokemon(userTrainer, false); }

                int userInputIndex = Menu.GetUserInputIndex(menuChoices, false);
                switch (userInputIndex)
                {
                    case 0:
                        Attack(userTrainer.PokemonOut, opponent);
                        break;
                    case 1:
                        Pokemon initialPokemon = userTrainer.PokemonOut;
                        ChangePokemon(userTrainer, true);
                        if (initialPokemon == userTrainer.PokemonOut) { break; }
                        OpponentMightAttack(userTrainer.PokemonOut, opponent);
                        break;
                    case 2:
                        InteractWithItems(userTrainer.PokemonOut, userTrainer, opponent);
                        // Opponent faints when it fails to break out of Pokeball.
                        if (opponent.Hp == 0) { return; }
                        break;
                    case 3:
                        if (Run(userTrainer.PokemonOut, opponent)) { return; };
                        break;
                }

            }
            if (opponent.Hp == 0)
            {
                Console.WriteLine($"{opponent.Name} fainted.");
                userTrainer.PokemonOut.GainExp(opponent.ExpReleased);
            }
            else
            {
                Console.WriteLine($"{userTrainer.PokemonOut.Name} fainted.");
            }
        }

        public static void FightTrainer(PokemonTrainer userTrainer, RivalTrainer opponentTrainer)
        {
            int nextPokemonIndex = 1;

            List<string> menuChoices = new List<string> { "Attack", "Change Popokenom", "Item", "Run" };

            Console.WriteLine($"{opponentTrainer.Name}: My {opponentTrainer.StarterPokemon} will beat your {userTrainer.StarterPokemon} for sure.");
            while (!opponentTrainer.AllPokemonsFainted() && !userTrainer.AllPokemonsFainted())
            {
                if (userTrainer.PokemonOut.Hp == 0) { ChangePokemon(userTrainer, false); }
                if (opponentTrainer.PokemonOut.Hp == 0)
                {
                    Console.WriteLine($"{opponentTrainer.PokemonOut.Name} fainted.");
                    userTrainer.PokemonOut.GainExp(opponentTrainer.PokemonOut.ExpReleased);
                    Console.WriteLine($"{opponentTrainer.Name}: You did well, {opponentTrainer.PokemonOut.Name}.");
                    opponentTrainer.SwapPokemons(0, nextPokemonIndex++);
                    Console.WriteLine($"{opponentTrainer.Name}: {opponentTrainer.PokemonOut.Name}, let's catch up the slack!");

                }

                int userInputIndex = Menu.GetUserInputIndex(menuChoices, false);
                switch (userInputIndex)
                {
                    case 0:
                        Attack(userTrainer.PokemonOut, opponentTrainer.PokemonOut);
                        break;
                    case 1:
                        Pokemon initialPokemon = userTrainer.PokemonOut;
                        ChangePokemon(userTrainer, true);
                        if (initialPokemon == userTrainer.PokemonOut) { break; }
                        OpponentMightAttack(userTrainer.PokemonOut, opponentTrainer.PokemonOut);
                        break;
                    case 2:
                        InteractWithItems(userTrainer.PokemonOut, userTrainer, opponentTrainer.PokemonOut);
                        break;
                    case 3:
                        Console.WriteLine($"{opponentTrainer.Name}: You can't run away from me, {userTrainer.Name}.");
                        break;
                }

            }
            if (opponentTrainer.AllPokemonsFainted())
            {
                Console.WriteLine($"{opponentTrainer.Name}: I'll have you next time.");
                userTrainer.Money += opponentTrainer.MoneyRewarded;
                Console.WriteLine($"{userTrainer.Name} earned ${opponentTrainer.MoneyRewarded}.");
            }
        }

        public static void Attack(Pokemon userPokemon, Pokemon opponent)
        {
            userPokemon.Attack(opponent);
            Console.WriteLine($"{opponent.Name} Hp drops to {opponent.Hp}.");
            if (opponent.Hp == 0) { return; }
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

        public static void ChangePokemon(PokemonTrainer userTrainer, bool cancel)
        {
            List<string> userChoices = new List<string>();
            for (int i = 1; i < userTrainer.CaptivePokemons.Count; i++)
            {
                Pokemon pokemon = userTrainer.CaptivePokemons[i];
                userChoices.Add($"{pokemon.Name} - Level: {pokemon.Level}, Hp: {pokemon.Hp}");
            }

            int userInputIndex = Menu.GetUserInputIndex(userChoices, cancel);

            if (userInputIndex == -1) { return; }
            Console.WriteLine($"Come back {userTrainer.PokemonOut.Name}.");

            userTrainer.SwapPokemons(0, userInputIndex + 1);
            Console.WriteLine($"I choose you, {userTrainer.PokemonOut.Name}.");
        }

        public static void InteractWithItems(Pokemon userPokemon, PokemonTrainer userTrainer, Pokemon opponent)
        {
            List<string> userItems = new List<string>();

            foreach (IItem item in userTrainer.Items)
            {
                string itemName = item.Name;
                userItems.Add(itemName);
            }
            int userInputIndex = Menu.GetUserInputIndex(userItems, true);

            if (userInputIndex == -1) { return; }
            IItem itemChosen = userTrainer.Items[userInputIndex];
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
