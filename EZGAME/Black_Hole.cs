using System;
namespace EZGAME
{
    class Black_Hole : Skill
    {
        public override int GetManaUsed()
        {
            return 20;
        }

        public override int GetDmgDealt()
        {
            return 20;
        }


        public override void RunSkill(Character caster, Character hit)
        {
           
        }

        public override string GetName()
        {
            return "Black Hole";
        }
    }
}
