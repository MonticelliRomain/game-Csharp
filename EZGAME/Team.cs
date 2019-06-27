using System;
using System.Collections.Generic;
namespace EZGAME
{
    public class Team
    {
        private List<Player> players;
        public List<Player> GetPlayers()
        {
            return players;
        }

        private int currentPlayer;
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

        private string name;
        public string GetName()
        {
            return name;
        }

        public Team(int nbOfPlayers, string name)
        {
            players = new List<Player>(nbOfPlayers);
            this.currentPlayer = 0;
            this.name = name;
        }
    }


}
