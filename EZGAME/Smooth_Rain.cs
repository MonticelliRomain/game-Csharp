using System;
namespace EZGAME
{
    class Smooth_Rain : Skill
    {
        public int GetManaUsed()
        {
            return 15;
        }

        public void RunSkill(Character caster, Character characterHit)
        {
            characterHit.vie -= 25;
            caster.mana -= GetManaUsed();
        }

        public string GetName()
        {
            return "Smooth Rain";
        }
    }
}
