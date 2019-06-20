using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Elf : Character
    {
        public Elf() : base(90, 75, "Elf")
        {
            AddSkill(new Deep_Arrow("Deep Arrow", 30, 38));
            AddSkill(new Smooth_Rain("Smooth Rain", 15, 25));
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
