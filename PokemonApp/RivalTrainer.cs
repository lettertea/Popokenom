using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class RivalTrainer : PokemonTrainer
    {
        public RivalTrainer(string name) : base(name)
        {
            this.Name = name;
        }

        public static void SetRivalPokemons(string userStarterPokemon, PokemonTrainer rival, int index)
        {
            int pokemonLevel = (index + 1) * 10;

            // Set starter pokemon
            if (userStarterPokemon == "Bulbasaur") { rival.CaptivePokemons.Add(new Pokemon("Charmander", pokemonLevel)); }
            else if (userStarterPokemon == "Charmander") { rival.CaptivePokemons.Add(new Pokemon("Squirtle", pokemonLevel)); }
            else { rival.CaptivePokemons.Add(new Pokemon("Bulbasaur", pokemonLevel)); }


            if (index == 9)
            {
                for (int i = 0; i < 5; i++) { rival.CaptivePokemons.Add(new Pokemon("Magikarp", pokemonLevel)); }
            }
            else if (index > 3)
            {
                for (int i = 0; i < 2; i++) { rival.CaptivePokemons.Add(new Pokemon("Magikarp", pokemonLevel)); }
                for (int i = 0; i < 3; i++)
                {
                    rival.CaptivePokemons.Add(new Pokemon(GetNonMagikarpPokemon(), pokemonLevel));
                }
            }
            else if (index > 0)
            {
                for (int i = 0; i < 2; i++) { rival.CaptivePokemons.Add(new Pokemon(GetNonMagikarpPokemon(), pokemonLevel)); }
            }

        }

        public static string GetNonMagikarpPokemon()
        {
            string randomPokemonName = PokemonStore.GetRandomPokemon();
            // Makes sure no more Magikarps are added
            while (randomPokemonName == "Magikarp")
            {
                randomPokemonName = PokemonStore.GetRandomPokemon();
            }
            return randomPokemonName;
        }
    }
}
