using System;
using System.Collections.Generic;

namespace EZGAME
{
    public abstract class Character
    {
        private List<Skill> skills;
        private int health;
        private int mana;
        private string name;

        protected Character(int health, int mana, string name) 
        {
            this.health = health;
            this.mana = mana;
            this.name = name;
            this.skills = new List<Skill>();
        }

        public List<Skill> GetSkills() { return this.skills; }
        public void AddSkill(Skill skill) { this.skills.Add(skill); }
        public void SetSkill(List<Skill> skill) { this.skills = skill; }

        public int GetHealth() { return this.health; }
        public void SetHealth(int value) { this.health = value; }
        public void DecHealth(int value) { this.health -= value; }

        public int GetMana() { return this.mana; }
        public void SetMana(int value) { this.mana = value; }
        public void DecMana(int value) { this.mana -= value; }

        public string GetName() { return this.name; }
        public void SetName(string value) { this.name = value; }



        abstract public string OnHit(); // display a taunt when hit
        abstract public string Hello(); // character opening phrase
        abstract public string OnDeath(); // character dying phrase
    }
}
