using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Magician : Character
    {
        public Magician()
        {
            CreateSkillList();
            AddSkill(new Black_Hole());
            AddSkill(new Hellfire());

            SetHealth(80);
            SetMana(100);
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
