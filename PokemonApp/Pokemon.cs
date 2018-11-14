using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Pokemon
    {
        public double Rarity { get; private set; }
        public string Name { get; set; }
        private int _hp;
        public int Hp
        {
            get { return _hp; }
            set
            {
                if (value < 0) { _hp = 0; }
                else if (value > this.MaxHp) { _hp = this.MaxHp; }
                else { _hp = value; }
            }
        }
        private int _level;
        public int Level
        {
            get { return _level; }
            set
            {
                if (value < 1 || value > 100) { throw new ArgumentOutOfRangeException("Level must be from 1 to 100"); }
                _level = value;
                
            }
        }
        public int Exp { get; set; }
        public int ExpToLevel => (int)(Math.Pow(this.Level +1, 3)/2.8);
        public int ExpReleased => (int)(this.ExpToLevel / (.1*(Math.Pow(this.Level, 1.3) + 1)) * this.Rarity);
        public int MaxHp => (int)((this.Level * 10) * Math.Pow(.2 * this.Level + 1, 1.17) * this.Rarity);
        public int BaseAttack => this.MaxHp / 3;
        public double CaptureProbability => (double)this.Hp/this.MaxHp; 

        Random rand = new Random();
        public Pokemon(string name, int level)
        {
            this.Name = name;
            this.Level = level;
            this.Rarity = .80 + (1.3 - .80) * Math.Pow(rand.NextDouble(), 1.75); // Bias distribution to lower rarity value
            if (this.Name == "Magikarp") { this.Rarity += .3; }
            this.Hp = this.MaxHp;
            this.Exp = 0;
        }


        public int Attack(Pokemon opponent) => opponent.Hp -= this.BaseAttack;


        public void GainExp(int expGained)
        {
            this.Exp += expGained;
            Console.WriteLine($"{this.Name} gained {expGained} EXP.");
            while (this.Exp >= this.ExpToLevel)
            {
                this.LevelUp();
            }
        }

        public void LevelUp()
        {
            while (this.Exp >= this.ExpToLevel)
            {
                this.Exp -= this.ExpToLevel;
                this.Level++;
                Console.WriteLine($"{this.Name} Leveled up to {this.Level}!");
            }
        }

    }
}
