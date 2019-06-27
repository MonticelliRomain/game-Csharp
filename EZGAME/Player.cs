using System;
using System.Collections.Generic;
namespace EZGAME
{
    public class Player
    {
        private int playerNumber;
        public int GetNumber()
        {
            return playerNumber;
        }

        private Character character;
        public Character GetCharacter() { return character; }




        //private int playerNumber;

        public Player(Character character, int playerNumber)
        {
            this.character = character;
            this.playerNumber = playerNumber;
            //this.playerNumber = playerNumber;
        }

        public void PrintStats()
        {
            Console.WriteLine("\nPlayer skills: ");
            for (int i = 0; i < GetCharacter().GetSkills().Count; i++)
            {
                Console.WriteLine(" ► " + GetCharacter().GetSkills()[i].GetName() + " (Damages:"
                 + GetCharacter().GetSkills()[i].GetDmgDealt() + " - Mana cost: " +
                 GetCharacter().GetSkills()[i].GetManaUsed() + ")");
            }

            Console.WriteLine(" ♥ Health: " + GetCharacter().GetHealth());
            Console.WriteLine(" ⁂ Mana: " + GetCharacter().GetMana());
            
        }

        public void ChooseSkill(Player Hit)
        {
            bool isSkillUsed = false;
            while (!isSkillUsed)
            {
                Console.WriteLine("Use one of your skill\n");
                string skillUsed = Console.ReadLine();

                for (int i = 0; i < GetCharacter().GetSkills().Count; i++) // loop through array to check if skill used exists
                {
                    if (skillUsed == GetCharacter().GetSkills()[i].GetName()) // it exists
                    {
                        if (GetCharacter().GetMana() - GetCharacter().GetSkills()[i].GetManaUsed() >= 0) // is mana sufficient
                        {
                            GetCharacter().GetSkills()[i].Run(GetCharacter(), Hit.GetCharacter());
                            isSkillUsed = true;
                        }

                        else
                        {
                            Console.WriteLine("Not enough mana for this skill");
                        }
                    }
                }
            }
        }

        public Player ChooseTarget(List<Player> ennemyTeam)
        {

            while (true)
            {
                int chosenPlayer = ShowEnnemies(ennemyTeam);
                foreach (var players in ennemyTeam)
                    if (players.GetNumber() == chosenPlayer)
                    {
                        return players;
                    }
            }
        }

        public int ShowEnnemies(List<Player> ennemyPlayers)
        {
            for (int i = 0; i < ennemyPlayers.Count; i++)
            {
                Console.WriteLine("\nPlayer {0} stats: ", ennemyPlayers[i].GetNumber());
                Console.WriteLine(" ♥ Health: " + ennemyPlayers[i].GetCharacter().GetHealth());
                Console.WriteLine(" ⁂ Mana: " + ennemyPlayers[i].GetCharacter().GetMana());
            }
            Console.WriteLine("Please enter the number of the player which you wish to attack");
            return (Int32.Parse(Console.ReadLine()));
        }
    }
}
