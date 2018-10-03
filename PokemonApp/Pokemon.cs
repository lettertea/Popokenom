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
        public int Level { get; set;}
        public int Exp { get; set; }
        public int ExpToLevel { get; set; }
        public int ExpReleased { get; set; }
        // Add Attack Skills array
        public Pokemon(string name, int hp, int baseAttack, int level)
        {
            this.Name = name;
            this.Hp = hp;
            this.BaseAttack = baseAttack;
            this.Level = level;
            this.Exp = 0;
            this.ExpToLevel = (int)Math.Round(Math.Pow(this.Level/.22, 2), 0);
            this.ExpReleased = (int)Math.Round(this.ExpToLevel / Math.Pow((1.5*this.Level), .75), 0) + 2;
        }
        public int Attack(ref Pokemon opponent)
        {
            int lowestAttack = (int)Math.Round(this.BaseAttack - this.BaseAttack * .1, 0);
            int highestAttack = (int)Math.Round(this.BaseAttack + this.BaseAttack * .1, 0);

            Random rand = new Random();
            int attackRange = rand.Next(lowestAttack, highestAttack + 1);

            return opponent.Hp -= attackRange;
        }
        public void GainExp(ref Pokemon opponent)
        {
            this.Exp += opponent.ExpReleased;
        }
        public void LevelUp()
        {
            if (this.Exp >= this.ExpToLevel)
            {
                this.Level++;
                this.Exp -= this.ExpToLevel;
            }
        }

    }
}
