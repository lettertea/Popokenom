using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class PotionStore
    {
        public static Potion GetPotion() => new Potion("Potion (Heals 30% of max hp)", 75, .30);
        public static Potion GetSuperPotionl() => new Potion("Super Potion (Heals 50% of max hp)", 200, .50);
        public static Potion GetHyperPotion() => new Potion("Hyper Potion (Heals 70% of max hp)", 400, .70);
        public static Potion GetMaxPotion() => new Potion("Max (Heals 100% of max hp)", 800, 1.0);
    }
}
