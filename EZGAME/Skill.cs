using System;
namespace EZGAME
{
    abstract class Skill
    {
        abstract public string GetName();
        abstract public int GetManaUsed();
        abstract public int GetDmgDealt();

        abstract public void RunSkill(Character caster, Character hit);

        // update caster mana and hp of character hit
        public void Run(Character caster, Character hit) 
        {
            caster.DecMana(GetManaUsed());
            hit.DecVie(GetDmgDealt());
            // RunSkill(caster, hit);
        }


    }
}
