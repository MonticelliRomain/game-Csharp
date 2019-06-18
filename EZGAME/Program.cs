using System;

namespace EZGAME
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string classPlayer1;
            string classPlayer2;

            Console.WriteLine("\n ▁ ▂ ▃ ▄ ▅ ▆ ▇ Welcome to the Game Rincé-De-Ouf ! █ ▇ ▆ ▅ ▄ ▂ ▁ \n");

            do 
            {
                Console.WriteLine(" Player 1, choose your class (magician - warrior - elf)");
                classPlayer1 = Console.ReadLine();
            }
            while (classPlayer1 != "magician" && classPlayer1 != "warrior" && classPlayer1 != "elf");

            do
            {
                Console.WriteLine("\nPlayer 2, choose your class (magician - warrior - elf)");
                classPlayer2 = Console.ReadLine();
            }
            while (classPlayer2 != "magician" && classPlayer2 != "warrior" && classPlayer2 != "elf");

            Character player1;
            Character player2;

                if (classPlayer1 == "magician")
            {
                player1 = new Magician();
            }

            else if(classPlayer1 == "warrior")
            {
                player1 = new Warrior();
            }
            else 
            {
                player1 = new Elf();
            }

            if (classPlayer2 == "magician")
            {
                player2 = new Magician();
            }

            else if (classPlayer2 == "warrior")
            {
                player2 = new Warrior();
            }
            else 
            {
                player2 = new Elf();
            }

            int playerTurn = 0; // 0 is for player1 turn and 1 for player2 turn
            bool gameOver = true;
            while (gameOver)
            {
                Character ToPlay; 
                Character Hit;

                if (playerTurn == 0)
                {
                    ToPlay = player1;
                    Hit = player2;
                }

                else
                {
                    ToPlay = player2;
                    Hit = player1;
                }

                Console.WriteLine("\n" + ToPlay.Hello());
                Console.WriteLine("Player skills: ");
                for (int i = 0; i < ToPlay.GetSkills().Count; i++)
                {
                    Console.WriteLine(" ► " + ToPlay.GetSkills()[i].GetName() + " (Damages:" + ToPlay.GetSkills()[i].GetDmgDealt() + " - Mana cost: " + ToPlay.GetSkills()[i].GetManaUsed() + ")");
                }

                Console.WriteLine(" ♥ Health: " + ToPlay.GetHealth());
                Console.WriteLine(" ⁂ Mana: " + ToPlay.GetMana());

                bool isSkillUsed = false;
                while (!isSkillUsed) 
                {
                    Console.WriteLine("Use one of your skill\n");
                    string skillUsed = Console.ReadLine();

                    for(int i = 0; i < ToPlay.GetSkills().Count; i++) // loop through array to check if skill used exists
                    {
                        if (skillUsed == ToPlay.GetSkills()[i].GetName()) // it exists
                        {
                            if (ToPlay.GetMana() - ToPlay.GetSkills()[i].GetManaUsed() >= 0) // is mana sufficient
                            {
                                ToPlay.GetSkills()[i].Run(ToPlay, Hit);
                                isSkillUsed = true;
                                playerTurn = (playerTurn + 1) % 2; // update player turn
                            }
                           
                            else
                            {
                                Console.WriteLine("Not enough mana for this skill");
                            }
                        }
                    }
                }

                if(Hit.GetHealth() <= 0)
                {
                    Console.WriteLine("\n† " + Hit.OnDeath() + " †");
                    gameOver = false;
                }

                else
                {
                    Console.Write("\n" + Hit.OnHit());
                }
            }
        }
    }
}

/*
 * Classe abstraite Character
-> List<Skill>
-> vie
-> mana

-> méthode abstract onHit()
-> méthode abstract hello()
Interface Skill
-> GetManaUsed()
-> RunSkill(Character hitted)
-> GetName()

Classe Warior

Casse Magician

------------------------ Définir les skills des deux classes (a votre sauce)

La partie se jouera a deux joueurs, au début le CLI demande a chaque joueur quel classe il veut (afficher toutes les classes dispo)

Ensuite tour par tour sa affiche la liste des Skill dispo sur cette classe ainsi que la vie et le mana restant du joueur
en fonction du skill utilisé sa le lancera sur le joueur adverse et fera l'effet du skill

la méthode OnHit du gars touché sera appelé
et la méthode hello() sera appelé a chaque début de tour
 */
