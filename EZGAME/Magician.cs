using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Magician : Character
    {
        public Magician()
        {
            skills = new List<Skill>();
            skills.Add(new Black_Hole());
            skills.Add(new Hellfire());

            vie = 80;
            mana = 100;
        }

        public override string OnHit()
        {
            return "You shall hit me from afar";
        }

        public override string Hello()
        {
            return "Prepare your anus for my scepter";
        }
    }
}
