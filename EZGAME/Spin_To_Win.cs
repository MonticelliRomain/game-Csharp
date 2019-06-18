using System;
namespace EZGAME
{
    class Spin_To_Win : Skill
    {
        public int GetManaUsed()
        {
            return 10;
        }

        public void RunSkill(Character caster, Character characterHit)
        {
            characterHit.vie -= 10;
            caster.mana -= GetManaUsed();
        }

        public string GetName()
        {
            return "Spin To Win";
        }
    }
}
