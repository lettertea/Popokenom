using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class ItemStore
    {
        private List<Item> _items = new List<Item> {
   new Pokeball("Pokeball (It's a ball of poke)", 50, 1.0),
   new Pokeball("Great Ball (It's pretty great)", 150, 1.5),
   new Pokeball("Ultra Ball (I have no puns for this)", 500, 2.0),
   new Pokeball("Pokeball (It's a ball of poke)", 50, 1.0),
   new Pokeball("Great Ball (It's pretty great)", 150, 1.5),
   new Pokeball("Ultra Ball (I have no puns for this)", 500, 2.0)
  };
    }
}
}