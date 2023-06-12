using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_AI_Player.Classes
{
    /*
     * Class Name: Player.
     * Description: class to be instantiated for each player in the game.
     * Attributes: name, score, sign.
     */
    public class Player
    {
        // Attributes
        private string name;                    // Player name
        private int score;                      // Player score
        private Position_Color sign;                    // Coin color

        // Costructor
        public Player (string name, Position_Color sign)
        {
            this.name = name;
            this.score = 0;
            this.sign = sign;
        }

        // Setters & getters
        public Position_Color Sign
        {
            get { return sign; }
            set { sign = value; }
        }

        public string PlayerName
        {
            get { return name; }
        }

        public int PlayerScore
        {
            get { return score; }
            set { score = value; }
        }

        // Method to get the opponent player coin color
        public Position_Color GetOpponentSign()
        {
            Position_Color opponentSign;
            if (this.sign == Position_Color.BLACK)
            {
                opponentSign = Position_Color.WHITE;
            }
            else
            {
                opponentSign = Position_Color.BLACK;
            }

            return opponentSign;
        }
    }
}
