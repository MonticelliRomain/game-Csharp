using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Elf : Character
    {
        public Elf()
        {
            skills = new List<Skill>();
            skills.Add(new Deep_Arrow());
            skills.Add(new Smooth_Rain());

            vie = 90;
            mana = 75;
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
