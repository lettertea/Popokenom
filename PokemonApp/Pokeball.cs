using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PokemonApp
{
    class Pokeball : Item
    {
        public double Effectiveness { get; set; }
        public override string PokemonAffected => "opponent";

        public Pokeball(string name, int price, double effectiveness) : base(name, price)
        {
            this.Effectiveness = effectiveness;
        }

        public override void Use(ref Pokemon opponent, ref PokemonTrainer userTrainer)
        {
            userTrainer.Items.Remove(this);
            double captureProbability = (double)(this.Effectiveness * opponent.CaptureProbability);
            Random rand = new Random();
            if (captureProbability * this.Effectiveness >= rand.NextDouble()) {
                userTrainer.CaptivePokemons.Add(opponent);
                Console.WriteLine($"{opponent.Name} has been caught!");
                Console.Write("While trying to break out, ");
                opponent.Hp = 0;
                return;
            }
            Console.WriteLine($"{opponent.Name} broke out!");
        }

    }
}
