using System;
using System.Collections.Generic;

namespace EZGAME
{
    class MainClass
    {
        public static void Main(string[] args)
        {

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

        public void RunSkill(Character hit)
        {

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

        public void RunSkill(Character hit)
        {

        }

        public string GetName()
        {
            return "Black Hole";
        }
    }


    class Black_Hole : Skill
    {
        public int GetManaUsed()
        {
            return 20;
        }

        public void RunSkill(Character hit)
        {

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
            return 30;
        }

        public void RunSkill(Character hit)
        {

        }

        public string GetName()
        {
            return "Hellfire";
        }
    }

    abstract class Character 
    {
        List <Skill> skills;
        int vie;
        int mana;
        string onHit() { return "il m'a frappé omg"; }
        string hello() { return "salut bitch"; }

    }
    class Warrior : Character
    {
        List <Skill> skills;

        int vie = 100;
        int mana = 50;

        public Warrior()
        {
            skills.Add(new Spin_To_Win());
            skills.Add(new Barronage());
        }

        public string onHit() 
        { 
            return "You can't milk those"; 
        }

        public string hello() 
        { 
            return "Salut moucheron"; 
        }
    }
    class Magician : Character
    {

        List <Skill> skills = new List<Skill> ();

        int vie = 80;
        int mana = 100;

        public Magician()
        {
            skills.Add(new Black_Hole());
            skills.Add(new Hellfire());
        }

        public string onHit()
        {
            return "You shall hit me from afar";
        }

        public string hello()
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
