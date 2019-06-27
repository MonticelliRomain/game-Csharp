using System;
using System.Collections.Generic;
namespace EZGAME
{
    public class Team
    {
        private List<Player> players;
        private int currentPlayer;
        private string name;

        public Team(int nbOfPlayers, string name)
        {
            players = new List<Player>(nbOfPlayers);
            this.currentPlayer = 0;
            this.name = name;
        }

        public List<Player> GetPlayers()
        {
            return players;
        }

        public int GetCurrentPlayer()
        {
            return currentPlayer;
        }

        public void NextPlayer()
        {
            currentPlayer = (currentPlayer + 1) % this.GetPlayers().Count;
        }

        public void ActualizePlayer()
        {
            currentPlayer = currentPlayer % this.GetPlayers().Count;
        }

        public string GetName()
        {
            return name;
        }
    }
}
