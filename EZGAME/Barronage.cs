using System;
namespace EZGAME
{
    class Barronage : Skill
    {
        public override int GetManaUsed()
        {
            return 15;
        }

        public override int GetDmgDealt()
        {
            return 30;
        }


        public override void RunSkill(Character caster, Character hit)
        {
        }

        public override string GetName()
        {
            return "Barronage";
        }
    }
}
