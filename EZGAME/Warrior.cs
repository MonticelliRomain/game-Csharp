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

            SetVie(100);
            SetMana(60);
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
