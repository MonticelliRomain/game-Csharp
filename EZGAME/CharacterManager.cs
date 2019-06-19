using System;
using System.Collections.Generic;

namespace EZGAME
{
    public sealed class CharacterManager
    {
        private Dictionary<string, Character> characters;
        public Dictionary<string, Character> GetMap()
        {
            return characters;
        }
        private static CharacterManager instance = null;

        /*public object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }*/

        public CharacterManager()
        {
            Register("magician", Magician);
            Register("warrior", Warrior);
            Register("elf", Elf);
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

        public void Register(string name, Character chara)
        {
            characters.Add(name, chara);
        }
    }
}
