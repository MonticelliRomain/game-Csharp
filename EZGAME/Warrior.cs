using System;
using System.Collections.Generic;

namespace EZGAME
{
    class Warrior : Character
    {
        public Warrior()
        {
            CreateSkillList();
            AddSkill(new Spin_To_Win());
            AddSkill(new Barronage());

            SetHealth(100);
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

        public override string OnDeath()
        {
            return "DEMACIAAAAAAAAA";
        }
    }
}
