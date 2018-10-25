using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Pokeballs
    {
        public Pokeball Pokeball()
        {
            return new Pokeball("Pokeball (It's a ball of poke)", 50, 1.0f);
        }
        public Pokeball GreatBall()
        {
            return new Pokeball("Great Ball (It's pretty great)", 150, 1.5f);
        }
        public Pokeball UltraBall()
        {
            return new Pokeball("Ultra Ball (I have no puns for this)", 500, 2.0f);
        }
    }
}
