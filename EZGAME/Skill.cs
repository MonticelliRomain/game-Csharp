using System;
namespace EZGAME
{
    abstract class Skill
    {
        abstract public int GetManaUsed();
        abstract public int GetDmgDealt();
        public void Run(Character caster, Character hit) 
        {
            caster.mana -= GetManaUsed();
            hit.vie -= GetDmgDealt();
            RunSkill(caster, hit);
        }
        abstract public void RunSkill(Character caster, Character hit); // update caster mana and hp of character hit
        abstract public string GetName();
    }
}
