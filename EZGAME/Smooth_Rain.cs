using System;
namespace EZGAME
{
    class Smooth_Rain : Skill
    {
        public override int GetManaUsed()
        {
            return 15;
        }

        public override int GetDmgDealt()
        {
            return 25;
        }

        public override void RunSkill(Character caster, Character hit)
        {
        }

        public override string GetName()
        {
            return "Smooth Rain";
        }
    }
}
