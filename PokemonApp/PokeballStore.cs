﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class PokeballStore
    {
        public static Pokeball GetPokeball() => new Pokeball("Pokeball (It's a ball of poke)", 50, 1.0);
        public static Pokeball GetGreatball() => new Pokeball("Great Ball (It's pretty great)", 150, 1.5);
        public static Pokeball GetUltraball() => new Pokeball("Ultra Ball (I have no puns for this)", 500, 2.0);
    }
}