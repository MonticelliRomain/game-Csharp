using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Warrior : Character
    {
        public Warrior()
        {
            skills = new List<Skill>();
            skills.Add(new Spin_To_Win());
            skills.Add(new Barronage());

            vie = 100;
            mana = 60;
        }

        public override string OnHit()
        {
            return "You can't milk those";
        }

        public override string Hello()
        {
            return "DEMACIAAAAAAAAA";
        }
    }
}
