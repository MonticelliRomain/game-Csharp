using System;
using System.Collections.Generic;

namespace EZGAME
{
    public sealed class CharacterManager
    {
        private Dictionary<string, Character> characters;
        private static CharacterManager instance = null;

        /*public object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }*/

        public CharacterManager()
        {
            characters.Add("Magician", new Magician());
            characters.Add("Warrior", new Warrior());
            characters.Add("Elf", new Elf());
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

        public void Register(string name)
        {
            Character created = null;
            for (int i = 0; i < characters.Count; i++)
            {
                if (this.characters[name] != null)
                {
                    created = this.characters[name];
                }
            }

        }
    }
}
