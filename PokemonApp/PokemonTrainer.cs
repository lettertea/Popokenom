using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    [Serializable]
    class PokemonTrainer
    {

        public List<Pokemon> CaptivePokemons { get; } = new List<Pokemon>();
        public Pokemon PokemonOut => this.CaptivePokemons[0];
        public string StarterPokemon { get; set; }

        public string Name { get; set; }
        public int Money { get; set; };
        public List<IItem> Items { get; } = new List<IItem>();

        public PokemonTrainer (string Name)
        {
            this.Name = Name;
        }

        public void SwapPokemons(int indexA, int indexB)
        {
            Pokemon cache = this.CaptivePokemons[indexA];
            this.CaptivePokemons[indexA] = this.CaptivePokemons[indexB];
            this.CaptivePokemons[indexB] = cache;
        }

        public bool AllPokemonsFainted()
        {
            foreach (Pokemon userPokemon in this.CaptivePokemons)
            {
                if (userPokemon.Hp > 0) { return false; }
            }
            return true;
        }

        public void HeallAllPokemons() => this.CaptivePokemons.ForEach(pokemon => pokemon.Hp = pokemon.MaxHp);

    }


}
