using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class ItemStore
    {
        public static List<IItem> Items { get; } = new List<IItem>
        {
        new Pokeball("Pokeball (It's a ball of poke)", 50, 1.0),
        new Pokeball("Great Ball (It's pretty great)", 150, 1.5),
        new Pokeball("Ultra Ball (I have no puns for this)", 500, 2.0),
        new Potion("Potion (Heals 30% of max hp)", 75, .30),
        new Potion("Super Potion (Heals 50% of max hp)", 200, .50),
        new Potion("Hyper Potion (Heals 70% of max hp)", 400, .70),
        new Potion("Max (Heals 100% of max hp)", 800, 1.0)
    };

        public static void PurchaseItem(PokemonTrainer trainer, int itemChoiceIndex)
        {
            Item
        }
    }

}