using System;
namespace EZGAME
{
    class Deep_Arrow : Skill
    {
        public override int GetManaUsed()
        {
            return 30;
        }

        public override int GetDmgDealt()
        {
            return 38;
        }

        public override void RunSkill(Character caster, Character hit)
        {
           
        }

        public override string GetName()
        {
            return "Deep Arrow";
        }
    }
}

