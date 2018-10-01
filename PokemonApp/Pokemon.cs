using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Pokemon
    {

        public string Name { get; set; }
        public int Hp { get; set; }
        public int BaseAttack { get; set; }

        public Pokemon(string name, int hp, int baseAttack)
        {
            this.Name = name;
            this.Hp = hp;
            this.BaseAttack = baseAttack;



        }
        public int Attack(ref Pokemon opponent)
        {
            int lowestAttack = (int)Math.Round(this.BaseAttack - this.BaseAttack * .1, 0);
            int highestAttack = (int)Math.Round(this.BaseAttack + this.BaseAttack * .1, 0);

            Random rand = new Random();
            int attackRange = rand.Next(lowestAttack, highestAttack + 1);

            return opponent.Hp -= attackRange;
        }
    }
}
