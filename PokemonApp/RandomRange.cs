using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class RandomRange
    {
        public static int GetRandomRange(int baseInt, float variation)
        {
            int lowestInt = (int)Math.Round(baseInt* (1 - variation), 0);
            int highestInt = (int)Math.Round(baseInt * (1 + variation), 0);

            Random rand = new Random();
            int intRange = rand.Next(lowestInt, highestInt + 1);
            return intRange;
        }
    }
}
