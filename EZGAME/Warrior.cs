using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Warrior : Character
    {
        public Warrior() : base(100, 60, "Warrior")
        {
            AddSkill(new Spin_To_Win("Spin To Win", 10, 10));
            AddSkill(new Barronage("Barronage", 15, 30));
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
