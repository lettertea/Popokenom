using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class PokemonTrainer
    {

        public List<Pokemon> CaptivePokemons { get; } = new List<Pokemon>();
        public string StarterPokemon { get; set; }

        public string Name { get; set; }
        public int Money { get; set; }
        public int MoneyDropped { get; set; }
        public List<Item> Items { get; } = new List<Item>();

        public PokemonTrainer (string Name)
        {
            this.Name = Name;
        }

        public void SwapPokemons(int indexA, int indexB)
        {
            Pokemon cache = this.CaptivePokemons[indexA];
            CaptivePokemons[indexA] = this.CaptivePokemons[indexB];
            this.CaptivePokemons[indexB] = cache;
        }

        public bool AllPokemonsFainted()
        {
            foreach (Pokemon userPokemon in this.CaptivePokemons)
            {
                if (userPokemon.Hp >= 0) { return false; }
            }
            return true;
        }
    }


}
