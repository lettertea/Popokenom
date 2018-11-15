using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    [Serializable]
    class Potion : IItem
    {

        public string Name { get; set; }
        public int Price { get; set; }
        public double HpIncrease { get; set; }
        public string PokemonAffected => "user";

        public Potion(string name, int price, double hpIncrease)
        {
            this.Name = name;
            this.Price = price;
            this.HpIncrease = hpIncrease;
        }

        public void Use(Pokemon userPokemon, PokemonTrainer userTrainer)
        {
            userTrainer.Items.Remove(this);
            int HpIncreased = (int)Math.Round((userPokemon.MaxHp * this.HpIncrease));
            if (userPokemon.Hp + HpIncreased > userPokemon.MaxHp) { HpIncreased = userPokemon.MaxHp - userPokemon.Hp; }
            userPokemon.Hp += HpIncreased;
            Console.WriteLine($"{userPokemon} recovered {HpIncreased} Hp to {userPokemon.Hp}");
        }
    }
}
