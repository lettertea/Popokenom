using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public Item(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }
    }
}
