using System;
namespace EZGAME
{
    interface Skill
    {
        int GetManaUsed();
        void RunSkill(Character caster, Character hit); // update caster mana and hp of character hit
        string GetName();
    }
}
