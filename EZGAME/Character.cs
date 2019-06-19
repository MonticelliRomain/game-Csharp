using System;
using System.Collections.Generic;

namespace EZGAME
{
    public abstract class Character
    {
        private List<Skill> skills;
        public List<Skill> GetSkills() { return this.skills; }
        public void AddSkill(Skill skill) { this.skills.Add(skill); }
        public void SetSkill(List<Skill> skill) { this.skills = skill; }
        public void CreateSkillList() { this.skills = new List<Skill>(); }

        private int health;
        public int GetHealth() { return this.health; }
        public void SetHealth(int value) { this.health = value; }
        public void DecHealth(int value) { this.health -= value; }

        private int mana;
        public int GetMana() { return this.mana; }
        public void SetMana(int value) { this.mana = value; }
        public void DecMana(int value) { this.mana -= value; }

        private string name;
        public string GetName() { return this.name; }
        public void SetName(string value) { this.name = value; }

        abstract public string OnHit(); // display a taunt when hit
        abstract public string Hello(); // character opening phrase
        abstract public string OnDeath(); // character dying phrase
    }
}
