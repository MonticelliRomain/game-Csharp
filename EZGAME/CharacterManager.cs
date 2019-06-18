using System;
using System.Collections.Generic;

namespace EZGAME
{
    public sealed class CharacterManager
    {
        private static CharacterManager instance = null;

        public void Register(string name)
        {
            Character created;
             
            switch (name)
            {
                case "magician":
                    created = new Magician();
                    break;
                case "elf":
                    created = new Elf();
                    break;
                case "warrior":
                    created = new Magician();
                    break;
            }
        }

        public CharacterManager()
        {
        }

        public static CharacterManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CharacterManager();
                }
                return instance;
            }
        }
    }
}
