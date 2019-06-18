using System;
namespace EZGAME
{
    class Hellfire : Skill
    {
        public override int GetManaUsed()
        {
            return 33;
        }

        public override int GetDmgDealt()
        {
            return 35;
        }


        public override void RunSkill(Character caster, Character hit)
        {

        }

        public override string GetName()
        {
            return "Hellfire";
        }
    }
}
