using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Potion : Item
    {
        public double HpIncrease { get; set; }
        public override string PokemonAffected => "user";
        public Potion(string name, int price, double HpIncrease) : base(name, price)
        {
            this.HpIncrease = HpIncrease;
        }

        public override void Use(ref Pokemon userPokemon, ref PokemonTrainer userTrainer)
        {
            userTrainer.Items.Remove(this);
            int HpIncreased = (int)Math.Round((userPokemon.MaxHp * this.HpIncrease));
            if (userPokemon.Hp + HpIncreased > userPokemon.MaxHp) { HpIncreased = userPokemon.MaxHp - userPokemon.Hp; }
            userPokemon.Hp += HpIncreased;
            Console.WriteLine($"{userPokemon} recovered {HpIncreased} Hp to {userPokemon.Hp}");
        }
    }
}
