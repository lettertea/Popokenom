using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokemonApp
{
    [Serializable]
    class Pokeball : IItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public double Effectiveness { get; set; }
        public string PokemonAffected => "opponent";

        public Pokeball(string name, int price, double effectiveness)
        {
            this.Name = name;
            this.Price = price;
            this.Effectiveness = effectiveness;
        }

        public void Use(Pokemon opponent, PokemonTrainer userTrainer)
        {
            if (userTrainer.CaptivePokemons.Count >= 6 )
            {
                Console.WriteLine("You have too many pokemons.");
                return;
            }
            userTrainer.Items.Remove(this);
            double captureProbability = (double)(this.Effectiveness * opponent.CaptureProbability);
            Random rand = new Random();
            if (captureProbability * this.Effectiveness >= rand.NextDouble()) {
                userTrainer.CaptivePokemons.Add(opponent);
                Console.WriteLine($"{opponent.Name} fainted while trying to break out.");
                Console.WriteLine($"{opponent.Name} has been caught!");
                opponent.Hp = 0;
                return;
            }
            Console.WriteLine($"{opponent.Name} broke out!");
        }

    }
}
