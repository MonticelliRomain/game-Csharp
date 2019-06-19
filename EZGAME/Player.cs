using System;
namespace EZGAME
{
    public class Player
    {
        private Character character;
        public Character GetCharacter() { return character; }

        private bool turn;
        public bool GetTurn() { return turn; }
        public void ChangeTurn() { turn = !turn; }

        //private int playerNumber;

        public Player(Character character, /*int playerNumber,*/ bool turn)
        {
            this.character = character;
            //this.playerNumber = playerNumber;
            this.turn = turn;
        }

    }
}
