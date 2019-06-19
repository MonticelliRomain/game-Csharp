using System;
using System.Collections.Generic;

namespace EZGAME
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            CharacterManager classmanager = new CharacterManager();
            Dictionary<string, Character>.KeyCollection keys = classmanager.GetMap().Keys;

            string message = "";
            foreach (string key in keys)
            {
                message += key;
                message += " ";
            }

            List<Player> players = new List<Player>();
            int nbOfPlayers = 2;
            string classPlayer;

            Console.WriteLine("\n ▁ ▂ ▃ ▄ ▅ ▆ ▇ Welcome to the Game Rincé-De-Ouf ! █ ▇ ▆ ▅ ▄ ▂ ▁ \n");

            for (int i = 1; i <= nbOfPlayers; i++)
            {
                do
                {
                    Console.WriteLine(" Player " + i +", choose your class (" + message + ")");
                    classPlayer = Console.ReadLine();
                }
                while (!classmanager.GetMap().ContainsKey(classPlayer));

                Character hero = classmanager.GetMap()[classPlayer];
                Player player;

                if (i == 1) {
                    player = new Player(hero, i, true);
                }

                else {
                    player = new Player(hero, i, false);
                }

                players.Add(player);
            }

            bool gameOver = true;
            while (gameOver)
            {
                Player ToPlay = null;
                int currentPlayer = 0;
                foreach(Player player in players)
                {
                    if(player.GetTurn() == true)
                    {
                        ToPlay = player;
                        currentPlayer = players.IndexOf(player);
                    }
                }
                Player Hit = players[(currentPlayer + 1) % players.Count];

                Console.WriteLine("\n" + ToPlay.GetCharacter().Hello());
                Console.WriteLine("Player skills: ");
                for (int i = 0; i < ToPlay.GetCharacter().GetSkills().Count; i++)
                {
                    Console.WriteLine(" ► " + ToPlay.GetCharacter().GetSkills()[i].GetName() + " (Damages:" + ToPlay.GetCharacter().GetSkills()[i].GetDmgDealt() + " - Mana cost: " + ToPlay.GetCharacter().GetSkills()[i].GetManaUsed() + ")");
                }

                Console.WriteLine(" ♥ Health: " + ToPlay.GetCharacter().GetHealth());
                Console.WriteLine(" ⁂ Mana: " + ToPlay.GetCharacter().GetMana());

                bool isSkillUsed = false;
                while (!isSkillUsed) 
                {
                    Console.WriteLine("Use one of your skill\n");
                    string skillUsed = Console.ReadLine();

                    for(int i = 0; i < ToPlay.GetCharacter().GetSkills().Count; i++) // loop through array to check if skill used exists
                    {
                        if (skillUsed == ToPlay.GetCharacter().GetSkills()[i].GetName()) // it exists
                        {
                            if (ToPlay.GetCharacter().GetMana() - ToPlay.GetCharacter().GetSkills()[i].GetManaUsed() >= 0) // is mana sufficient
                            {
                                ToPlay.GetCharacter().GetSkills()[i].Run(ToPlay.GetCharacter(), Hit.GetCharacter());
                                isSkillUsed = true;
                                ToPlay.ChangeTurn();
                                players[(currentPlayer + 1) % players.Count].ChangeTurn(); // update player turn
                            }
                           
                            else
                            {
                                Console.WriteLine("Not enough mana for this skill");
                            }
                        }
                    }
                }

                if(Hit.GetCharacter().GetHealth() <= 0)
                {
                    Console.WriteLine("\n† " + Hit.GetCharacter().OnDeath() + " †");
                    gameOver = false;
                }

                else
                {
                    Console.Write("\n" + Hit.GetCharacter().OnHit());
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
