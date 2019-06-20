using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Warrior : Character
    {
        public Warrior() : base(100, 60, "Warrior")
        {
            AddSkill(new Spin_To_Win());
            AddSkill(new Barronage());
        }

        public override string OnHit()
        {
            return "You can't milk those";
        }

        public override string Hello()
        {
            return "DEMACIAAAAAAAAA";
        }

        public override string OnDeath()
        {
            return "DEMACIAAAAAAAAA";
        }
    }
}
