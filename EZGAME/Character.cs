using System;
using System.Collections.Generic;

namespace EZGAME
{
    abstract class Character
    {
        public List<Skill> skills; 
        public int vie;
        public int mana;
        abstract public string OnHit(); // display a taunt when hit
        abstract public string Hello(); // character opening phrase

    }
}
