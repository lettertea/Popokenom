using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    interface IItem
    {
        string Name { get; set; }
        int Price { get; set; }
        string PokemonAffected { get; }
        void Use(Pokemon pokemon, PokemonTrainer userTrainer);

    }
}
