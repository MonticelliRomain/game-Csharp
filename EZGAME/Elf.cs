using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Elf : Character
    {
        public Elf()
        {
            CreateSkillList();
            AddSkill(new Deep_Arrow());
            AddSkill(new Smooth_Rain());

            SetHealth(90);
            SetMana(75);
        }
        public override string OnHit()
        {
            return "Wow ! I'll come for your booty you dumbass !";
        }

        public override string Hello()
        {
            return "My string is so stretched !";
        }

    }
}
