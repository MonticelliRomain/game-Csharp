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

            string message = String.Format("({0})", string.Join("-", CharacterManager.Instance.GetMap().Keys));

            List<Player> players = new List<Player>();
            int nbOfPlayers = 2;
            string classPlayer;

            Console.WriteLine("\n ▁ ▂ ▃ ▄ ▅ ▆ ▇ Welcome to the Game Rincé-De-Ouf ! █ ▇ ▆ ▅ ▄ ▂ ▁ \n");

            for (int i = 1; i <= nbOfPlayers; i++)
            {
                do
                {
                    Console.WriteLine(" Player " + i +", choose your class "  + message);
                    classPlayer = Console.ReadLine();
                }
                while (!CharacterManager.Instance.GetMap().ContainsKey(classPlayer));

                Player player;
                Character hero = (Character) Activator.CreateInstance(CharacterManager.Instance.GetMap()[classPlayer]);

                player = new Player(hero);
                players.Add(player);
            }

            bool gameOver = true;
            int playerTurn = 0;

            while (gameOver)
            {
                players[playerTurn].GetCharacter().Hello();
                players[playerTurn].PrintStats();

                int nextPlayer = (playerTurn + 1) % players.Count;

                players[playerTurn].ChooseSkill(players[nextPlayer]);
                playerTurn++;

                if(players[nextPlayer].GetCharacter().GetHealth() <= 0)
                {
                    Console.WriteLine("\n† " + players[nextPlayer].GetCharacter().OnDeath() + " †");
                    gameOver = false;
                }

                else
                {
                    Console.Write("\n" + players[nextPlayer].GetCharacter().OnHit());
                }
            }
        }
    }
}