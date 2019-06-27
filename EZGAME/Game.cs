using System;
using System.Collections.Generic;
namespace EZGAME
{

    public class Game
    {
        private List<Team> teams;
        public List<Team> GetTeams()
        {
            return teams;
        }

        private bool gameOver;
        public void GameOver()
        {
            gameOver = !gameOver;
        }

        private int nbOfPlayers;

        public Game(int nbOfPlayers)
        {
           
            this.nbOfPlayers = nbOfPlayers;
            this.gameOver = false;
            teams = new List<Team>();
            teams.Add(new Team(nbOfPlayers, "Team one"));
            teams.Add(new Team(nbOfPlayers, "Team two"));

        }

        public void StartGame()
        {

            CreateTeams();

            int teamTurn = 0; 
            while (!gameOver)
            {

                teamTurn = (teamTurn + 1) % teams.Count;
            }
        }

        public int ShowEnnemies(List<Player> ennemyPlayers)
        {
            for(int i = 0; i < ennemyPlayers.Count; i++)
            {
                Console.WriteLine("\nPlayer {0} stats: ", ennemyPlayers[i].GetNumber());
                Console.WriteLine(" ♥ Health: " + ennemyPlayers[i].GetCharacter().GetHealth());
                Console.WriteLine(" ⁂ Mana: " + ennemyPlayers[i].GetCharacter().GetMana());
            }
            Console.WriteLine("Please enter the number of the player which you wish to attack");
            return(Int32.Parse(Console.ReadLine()));
        }

        public void CreateTeams()
        {
            string message = String.Format("({0})", string.Join("-", CharacterManager.Instance.GetMap().Keys));
            string classPlayer;

            Console.WriteLine("\n ▁ ▂ ▃ ▄ ▅ ▆ ▇ Welcome to the Game Rincé-De-Ouf ! █ ▇ ▆ ▅ ▄ ▂ ▁ \n");
            string teamName = teams[0].GetName();

            for (int i = 1; i <= nbOfPlayers; i++)
            {
                do
                {

                    Console.WriteLine(" Player " + i + " from " + teamName + ", choose your class " + message);
                    classPlayer = Console.ReadLine();
                    if (i == nbOfPlayers / 2)
                    {
                        teamName = teams[1].GetName();
                    }

                }
                while (!CharacterManager.Instance.GetMap().ContainsKey(classPlayer));

                Character hero = (Character)Activator.CreateInstance(CharacterManager.Instance.GetMap()[classPlayer]);
                if (i <= nbOfPlayers / 2)
                {
                    teams[0].GetPlayers().Add(new Player(hero, i));
                }

                else
                {
                    teams[1].GetPlayers().Add(new Player(hero, i));
                }
            }
        }

        public void PlayTurn(int teamTurn)
        {
            int playerTurn = teams[teamTurn].GetCurrentPlayer();
            teams[teamTurn].GetPlayers()[playerTurn].GetCharacter().Hello();
            teams[teamTurn].GetPlayers()[playerTurn].PrintStats();
            int ennemyTeam = (teamTurn + 1) % teams.Count;
            bool hasChoosedTarget = false;
            Player ToHit = null;
            while (!hasChoosedTarget)
            {
                int playerNumber = ShowEnnemies(teams[ennemyTeam].GetPlayers());
                foreach (var players in teams[ennemyTeam].GetPlayers())
                    if (players.GetNumber() == playerNumber)
                    {
                        hasChoosedTarget = true;
                        ToHit = players;
                    }
            }
            int nextPlayer = (playerTurn + 1) % teams[teamTurn].GetPlayers().Count;
            teams[teamTurn].GetPlayers()[playerTurn].ChooseSkill(ToHit);
            teams[teamTurn].NextPlayer();

            if (ToHit.GetCharacter().GetHealth() <= 0)
            {
                Console.WriteLine("\n† " + ToHit.GetCharacter().OnDeath() + " †");
                Console.Write("{0} {1}", ennemyTeam, teams[ennemyTeam].GetPlayers()[0].GetCharacter().OnDeath());
                int index = teams[ennemyTeam].GetPlayers().IndexOf(ToHit);
                teams[ennemyTeam].GetPlayers().RemoveAt(index);

                if (teams[ennemyTeam].GetPlayers().Count == teams[ennemyTeam].GetCurrentPlayer())
                {
                    teams[ennemyTeam].ActualizePlayer();
                }

                if (teams[ennemyTeam].GetPlayers().Count == 0)
                {
                    gameOver = true;
                }
            }

            else
            {
                Console.Write("\n" + ToHit.GetCharacter().OnHit());
            }
        }
    }
}
