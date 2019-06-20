using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Elf : Character
    {
        public Elf() : base(90, 75, "Elf")
        {
            AddSkill(new Deep_Arrow());
            AddSkill(new Smooth_Rain());
        }

        public override string OnHit()
        {
            return "Wow ! I'll come for your booty you dumbass !";
        }

        public override string Hello()
        {
            return "My string is so stretched !";
        }

        public override string OnDeath()
        {
            return "My string isn't stretched anymore...";
        }
    }
}
