using System;
namespace EZGAME
{
    class Deep_Arrow : Skill
    {
        public int GetManaUsed()
        {
            return 30;
        }

        public void RunSkill(Character caster, Character characterHit)
        {
            characterHit.vie -= 38;
            caster.mana -= GetManaUsed();
        }

        public string GetName()
        {
            return "Deep Arrow";
        }
    }
}

