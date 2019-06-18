using System;
namespace EZGAME
{
    class Barronage : Skill
    {
        public int GetManaUsed()
        {
            return 15;
        }

        public void RunSkill(Character caster, Character characterHit)
        {
            characterHit.vie -= 30;
            caster.mana -= GetManaUsed();
        }

        public string GetName()
        {
            return "Barronage";
        }
    }
}
