using System;
namespace EZGAME
{
    class Hellfire : Skill
    {
        public int GetManaUsed()
        {
            return 33;
        }

        public void RunSkill(Character caster, Character characterHit)
        {
            characterHit.vie -= 35;
            caster.mana -= GetManaUsed();
        }

        public string GetName()
        {
            return "Hellfire";
        }
    }
}
