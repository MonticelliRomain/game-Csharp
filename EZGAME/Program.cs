using System;
using System.Collections.Generic;

namespace EZGAME
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CharacterManager.Instance.Register<Magician>("magician");
            CharacterManager.Instance.Register<Warrior>("warrior");
            CharacterManager.Instance.Register<Elf>("elf");

            Game myGame = new Game(4);
            myGame.StartGame();
        }
    }
}