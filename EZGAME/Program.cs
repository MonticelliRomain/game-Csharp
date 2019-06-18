using System;
using System.Collections.Generic;

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

            int playerTurn = 0;
            bool gameOver = true;
            while (gameOver)
            {
                Character ToPlay;
                Character ToHit;

                if (playerTurn == 0)
                {
                    ToPlay = player1;
                    ToHit = player2;
                }

                else
                {
                    ToPlay = player2;
                    ToHit = player1;
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
                    Console.WriteLine("Use of your skill\n");
                    string skillUsed = Console.ReadLine();
                    for(int i = 0; i < ToPlay.skills.Count; i++)
                    {
                        if (skillUsed == ToPlay.skills[i].GetName())
                        {
                            int manaLeft = ToPlay.mana - ToPlay.skills[i].GetManaUsed();
                            if (manaLeft >= 0)
                            {
                                ToPlay.mana = manaLeft;
                                ToPlay.skills[i].RunSkill(ToHit);
                                isSkillUsed = true;
                                Console.Write("\n" + ToHit.OnHit());
                                playerTurn = (playerTurn + 1) % 2;
                            }
                            else
                            {
                                Console.WriteLine("Not enough mana for this skill");
                            }
                        }
                    }
                }

                if(ToHit.vie <= 0)
                {
                    gameOver = false;
                }
            }
        }
    }

    interface Skill
    {
        int GetManaUsed();
        void RunSkill(Character character);
        string GetName();

    }

    class Spin_To_Win : Skill
    {
        public int GetManaUsed()
        {
            return 10;
        }

        public void RunSkill(Character characterHit)
        {
            characterHit.vie -= 10;
        }

        public string GetName()
        {
            return "Spin To Win";
        }
    }

    class Barronage : Skill
    {
        public int GetManaUsed()
        {
            return 15;
        }

        public void RunSkill(Character characterHit)
        {
            characterHit.vie -= 17;
        }

        public string GetName()
        {
            return "Barronage";
        }
    }


    class Black_Hole : Skill
    {
        public int GetManaUsed()
        {
            return 20;
        }

        public void RunSkill(Character characterHit)
        {
            characterHit.vie -= 20;
        }

        public string GetName()
        {
            return "Black Hole";
        }
    }

    class Hellfire : Skill
    {
        public int GetManaUsed()
        {
            return 35;
        }

        public void RunSkill(Character characterHit)
        {
            characterHit.vie -= 35;
        }

        public string GetName()
        {
            return "Hellfire";
        }
    }

    abstract class Character 
    {
        public List<Skill> skills;
        public int vie;
        public int mana;
        abstract public string OnHit();
        abstract public string Hello();

    }
    class Warrior : Character
    {

        public Warrior()
        {
            skills = new List<Skill>();
            skills.Add(new Spin_To_Win());
            skills.Add(new Barronage());

            vie = 100;
            mana = 60;
        }

        public override string OnHit() 
        { 
            return "You can't milk those"; 
        }

        public override string Hello() 
        { 
            return "Salut moucheron"; 
        }
    }
    class Magician : Character
    {
       
        public Magician()
        {
            skills = new List<Skill>();
            skills.Add(new Black_Hole());
            skills.Add(new Hellfire());

            vie = 80;
            mana = 100;
        }

        public override string OnHit()
        {
            return "You shall hit me from afar";
        }

        public override string Hello()
        {
            return "Prepare your anus for my scepter";
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
