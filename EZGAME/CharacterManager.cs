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
            characters = new Dictionary<string, Character>();
            var magician = new Magician();
            var warrior = new Warrior();
            var elf = new Elf();

            Register<Magician>("magician", ref magician);
            Register<Warrior>("warrior", ref warrior);
            Register<Elf>("elf", ref elf);
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

        public void Register<T>(string name, ref T chara) where T : Character
        {
            characters.Add(name, chara);
        }
    }
}
