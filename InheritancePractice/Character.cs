using System;
using System.Collections.Generic;
using System.Text;

namespace InheritancePractice
{
    class Character
    {
        private int Health { get; set; }
        private int Strength { get; set; }
        private int Magic { get; set; }

        public Character(int health, int strength, int magic)
        {
            Health = health;
            Strength = strength;
            Magic = magic;
        }


    }
}
