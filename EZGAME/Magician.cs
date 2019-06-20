using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Magician : Character
    {
        public Magician() : base(80, 100, "Magician")
        {
            AddSkill(new Black_Hole("Black Hole", 20, 20));
            AddSkill(new Hellfire("Hellfire", 33, 35));
        }

        public override string OnHit()
        {
            return "You shall hit me from afar";
        }

        public override string Hello()
        {
            return "Prepare your anus for my scepter";
        }

        public override string OnDeath()
        {
            return "You took my scepter, I'm now an ermit";
        }
    }
}
