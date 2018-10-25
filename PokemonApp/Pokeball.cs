using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Pokeball : Item
    {
        public float Effectiveness { get; set; }
        public Pokeball(string name, int price, float effectiveness) : base(name, price)
        {
            this.Effectiveness = effectiveness;
        }

    }
}
