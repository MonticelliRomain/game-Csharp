using System;
using System.Collections.Generic;
namespace EZGAME
{

    public class Game
    {
        private List<Player> players;
        private int nbOfPlayers;

        public Game(int nbOfPlayers)
        {
            this.players = new List<Player>();
            this.nbOfPlayers = nbOfPlayers;
        }

        public void StartGame()
        {
            string message = String.Format("({0})", string.Join("-", CharacterManager.Instance.GetMap().Keys));
            string classPlayer;

            Console.WriteLine("\n ▁ ▂ ▃ ▄ ▅ ▆ ▇ Welcome to the Game Rincé-De-Ouf ! █ ▇ ▆ ▅ ▄ ▂ ▁ \n");

            for (int i = 1; i <= nbOfPlayers; i++)
            {
                do
                {
                    Console.WriteLine(" Player " + i + ", choose your class " + message);
                    classPlayer = Console.ReadLine();
                }
                while (!CharacterManager.Instance.GetMap().ContainsKey(classPlayer));

                Character hero = (Character)Activator.CreateInstance(CharacterManager.Instance.GetMap()[classPlayer]);

                players.Add(new Player(hero));
            }

            bool gameOver = true;
            int playerTurn = 0;

            while (gameOver)
            {
                players[playerTurn].GetCharacter().Hello();
                players[playerTurn].PrintStats();

                int nextPlayer = (playerTurn + 1) % players.Count;
                players[playerTurn].ChooseSkill(players[nextPlayer]);
                playerTurn = (playerTurn + 1) % players.Count;

                if (players[nextPlayer].GetCharacter().GetHealth() <= 0)
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
