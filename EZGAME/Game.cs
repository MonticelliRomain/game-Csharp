using System;
using System.Collections.Generic;
namespace EZGAME
{

    public class Game
    {
        private List<Team> teams;
        private bool gameOver;
        private int nbOfPlayers;

        public Game(int nbOfPlayers)
        {
           
            this.nbOfPlayers = nbOfPlayers;
            this.gameOver = false;
            teams = new List<Team>();
            teams.Add(new Team(nbOfPlayers, "Team one"));
            teams.Add(new Team(nbOfPlayers, "Team two"));

        }

        public void GameOver()
        {
            gameOver = !gameOver;
        }

        public List<Team> GetTeams()
        {
            return teams;
        }

        public void StartGame()
        {

            CreateTeams();

            int teamTurn = 0; 
            while (!gameOver)
            {
                PlayTurn(teamTurn);
                teamTurn = (teamTurn + 1) % teams.Count;
            }
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

            Player ToHit = teams[teamTurn].GetPlayers()[playerTurn].ChooseTarget(teams[ennemyTeam].GetPlayers());

            int nextPlayer = (playerTurn + 1) % teams[teamTurn].GetPlayers().Count;
            teams[teamTurn].GetPlayers()[playerTurn].ChooseSkill(ToHit);
            teams[teamTurn].NextPlayer();

            if (ToHit.GetCharacter().GetHealth() <= 0)
            {
                Console.WriteLine("\n† " + ToHit.GetCharacter().OnDeath() + " †");
                int index = teams[ennemyTeam].GetPlayers().IndexOf(ToHit);
                teams[ennemyTeam].GetPlayers().RemoveAt(index);

                if (teams[ennemyTeam].GetPlayers().Count == 0)
                {
                    gameOver = true;
                }

                else if (teams[ennemyTeam].GetPlayers().Count == teams[ennemyTeam].GetCurrentPlayer())
                {
                    teams[ennemyTeam].ActualizePlayer();
                }


            }

            else
            {
                Console.Write("\n" + ToHit.GetCharacter().OnHit());
            }
        }
    }
}
