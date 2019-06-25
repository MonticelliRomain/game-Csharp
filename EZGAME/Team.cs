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

        private string name;
        public string GetName()
        {
            return name;
        }

        public Team(int nbOfPlayers, string name)
        {
            players = new List<Player>(nbOfPlayers);
            this.name = name;
        }
    }


}
