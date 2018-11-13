using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    abstract class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public abstract string PokemonAffected { get; }
        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public abstract void Use(Pokemon pokemon, PokemonTrainer userTrainer);

    }
}
