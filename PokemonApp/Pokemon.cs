using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Pokemon
    {
        Random rand = new Random();
        public float Rarity => rand.Next(70,131) / 100;
        public string Name { get; set; }
        public int Hp { get; set; }
        public int BaseAttack { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int ExpToLevel => (int)Math.Round(Math.Pow(this.Level / .17, 2), 0);
        public int ExpReleased => (int)Math.Round((this.ExpToLevel / (.1 * Math.Pow(this.Level, 1.3) + 1) * (1 + this.Rarity)), 0) ; // expression bodied property
        public int MaxHp => RandomRange.GetRandomRange((int)Math.Round((this.Level *100) * Math.Pow(.2*this.Level, 1.17) , 0), this.Rarity);
        // Todo: add Type


        public Pokemon(string name, int level)
        {
            this.Name = name;
            this.Level = level;
            this.Hp = this.MaxHp;
            this.Exp = 0;

        }


        public int Attack(ref Pokemon opponent) => opponent.Hp -= this.BaseAttack;


        public int GainExp(Pokemon opponent)
        {
            int expReleasedRange = RandomRange.GetRandomRange(opponent.ExpReleased, 0.1f);
            this.Exp += expReleasedRange;
            this.LevelUp();
            opponent.Level = this.Level;
            return expReleasedRange;
        }

        public void LevelUp()
        {
            while (this.Exp >= this.ExpToLevel)
            {
                this.Exp -= this.ExpToLevel;
                this.Level++;
                Console.WriteLine($"You are Level {this.Level}");
            }
        }

    }
}
