using System;
namespace EZGAME
{
    class Spin_To_Win : Skill
    {
        public override int GetManaUsed()
        {
            return 10;
        }

        public override int GetDmgDealt()
        {
            return 10;
        }

        public override void RunSkill(Character caster, Character hit)
        {

        }

        public override string GetName()
        {
            return "Spin To Win";
        }
    }
}
