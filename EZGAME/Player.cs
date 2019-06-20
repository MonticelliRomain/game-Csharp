using System;
namespace EZGAME
{
    public class Player
    {
        private Character character;
        public Character GetCharacter() { return character; }




        //private int playerNumber;

        public Player(Character character /*int playerNumber,*/)
        {
            this.character = character;
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
    }
}
