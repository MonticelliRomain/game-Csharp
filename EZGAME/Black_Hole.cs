using System;
namespace EZGAME
{
    class Black_Hole : Skill
    {
        public int GetManaUsed()
        {
            return 20;
        }

        public void RunSkill(Character caster, Character characterHit)
        {
            characterHit.vie -= 20;
            caster.mana -= GetManaUsed();
        }

        public string GetName()
        {
            return "Black Hole";
        }
    }
}
