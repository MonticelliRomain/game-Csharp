using System;
namespace EZGAME
{
    public abstract class Skill
    {
        private string name;
        private int mana;
        private int dmg;

        public Skill(string name, int mana, int dmg)
        {
            this.name = name;
            this.mana = mana;
            this.dmg = dmg;
        }

        public string GetName() { return name; }
        public int GetManaUsed() { return mana; }
        public int GetDmgDealt() { return dmg; }

        abstract public void RunSkill(Character caster, Character hit);

        // update caster mana and hp of character hit
        public void Run(Character caster, Character hit) 
        {
            caster.DecMana(GetManaUsed());
            hit.DecHealth(GetDmgDealt());
            // RunSkill(caster, hit);
        }
    }
}
