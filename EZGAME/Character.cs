using System;
using System.Collections.Generic;

namespace EZGAME
{
    abstract class Character
    {
        public List<Skill> skills; 

        private int vie;
        public int GetVie() { return this.vie; }
        public void SetVie(int value) { this.vie = value; }
        public void DecVie(int value) { this.vie -= value; }

        private int mana;
        public int GetMana() { return this.mana; }
        public void SetMana(int value) { this.mana = value; }
        public void DecMana(int value) { this.mana -= value; }

        abstract public string OnHit(); // display a taunt when hit
        abstract public string Hello(); // character opening phrase

    }
}
