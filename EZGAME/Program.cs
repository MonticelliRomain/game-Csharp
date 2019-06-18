using System;

namespace EZGAME
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string classPlayer1;
            string classPlayer2;

            do 
            {
                Console.WriteLine(" Player 1, choose your class (magician - warrior)");
                classPlayer1 = Console.ReadLine();
            }
            while (classPlayer1 != "magician" && classPlayer1 != "warrior");

            do
            {
                Console.WriteLine("\nPlayer 2, choose your class (magician - warrior)");
                classPlayer2 = Console.ReadLine();
            }
            while (classPlayer2 != "magician" && classPlayer2 != "warrior");

            Character player1;
            Character player2;

                if (classPlayer1 == "magician")
            {
                player1 = new Magician();
            }

            else
            {
                player1 = new Warrior();
            }

            if (classPlayer2 == "magician")
            {
                player2 = new Magician();
            }

            else
            {
                player2 = new Warrior();
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
                for (int i = 0; i < ToPlay.skills.Count; i++)
                {
                    Console.WriteLine(ToPlay.skills[i].GetName() + " (mana cost: " + ToPlay.skills[i].GetManaUsed() + ")");
                }

                Console.WriteLine("Vie: " + ToPlay.vie);
                Console.WriteLine("Mana: " + ToPlay.mana);

                bool isSkillUsed = false;
                while (!isSkillUsed) 
                {
                    Console.WriteLine("Use one of your skill\n");
                    string skillUsed = Console.ReadLine();

                    for(int i = 0; i < ToPlay.skills.Count; i++) // loop through array to check if skill used exists
                    {
                        if (skillUsed == ToPlay.skills[i].GetName()) // it exists
                        {
                            if (ToPlay.mana - ToPlay.skills[i].GetManaUsed() > 0) // is mana sufficient
                            {
                                ToPlay.skills[i].RunSkill(ToPlay, Hit);
                                isSkillUsed = true;
                                Console.Write("\n" + Hit.OnHit());
                                playerTurn = (playerTurn + 1) % 2; // update player turn
                            }
                           
                            else
                            {
                                Console.WriteLine("Not enough mana for this skill");
                            }
                        }
                    }
                }

                if(Hit.vie <= 0)
                {
                    gameOver = false;
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
