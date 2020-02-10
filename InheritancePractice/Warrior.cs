using System;
using System.Collections.Generic;
using System.Text;

namespace InheritancePractice
{
    class Warrior : Character
    {
        private int health;
        private int strength;
        private int magic;

        public Warrior(int health, int strength, int magic)
            :base (health,strength,magic)
        {
            this.health = health;
            this.strength = strength;
            this.magic = magic;
        }

        public override string ToString()
        {
            return 
                $"\nHealth: {health}" +
                $"\nStrength: {strength}" +
                $"\nMagic: {magic}";
        }


    }
}
