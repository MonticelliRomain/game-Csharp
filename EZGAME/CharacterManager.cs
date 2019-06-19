using System;
using System.Collections.Generic;

namespace EZGAME
{
    public sealed class CharacterManager
    {
        private List<Character> characters;
        private static CharacterManager instance = null;

        public object GetInstance(string strFullyQualifiedName)
        {
            Type t = Type.GetType(strFullyQualifiedName);
            return Activator.CreateInstance(t);
        }

        public void Register(string name, List<Character> charas)
        {
            Character created = null;
            for(int i = 0; i < characters.Count; i++)
            {
                if(name == this.characters[i].GetName())
                {
                    created = (Character) GetInstance(name);
                }
            }
            charas.Add(created);
        }

        public CharacterManager()
        {
            characters.Add(new Magician());
            characters.Add(new Warrior());
            characters.Add(new Elf());
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
