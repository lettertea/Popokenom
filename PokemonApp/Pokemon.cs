﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonApp
{
    class Pokemon
    {
        public double Rarity { get; private set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int ExpToLevel => (int)Math.Round(Math.Pow(this.Level / .17, 2), 0);
        public int ExpReleased => (int)Math.Round((this.ExpToLevel / (.1 * Math.Pow(this.Level, 1.3) + 1) * (this.Rarity)), 0); // expression bodied property
        public int MaxHp => (int)Math.Round(((this.Level * 10) * Math.Pow(.2 * this.Level+1, 1.17) * this.Rarity), 0);
        public int BaseAttack => (int)Math.Round(this.MaxHp / 3.0, 0);


        Random rand = new Random();
        public Pokemon(string name, int level)
        {
            this.Rarity = .80 + (1.3 - .80) * Math.Pow(rand.NextDouble(), 1.75); // Bias distribution to lower rarity value
            this.Name = name;
            this.Level = level;
            this.Hp = this.MaxHp;
            this.Exp = 0;

        }


        public int Attack(ref Pokemon opponent) => opponent.Hp -= this.BaseAttack;


        public int GainExp(Pokemon opponent)
        {
            this.Exp += opponent.ExpReleased;
            while (this.Exp >= this.ExpToLevel)
            {
                this.LevelUp();
            }
            return opponent.ExpReleased;
        }

        public void LevelUp()
        {
            while (this.Exp >= this.ExpToLevel)
            {
                this.Exp -= this.ExpToLevel;
                this.Level++;
                Console.WriteLine($"Leveled up! {this.Name} is level {this.Level}.");
            }
        }

    }
}
