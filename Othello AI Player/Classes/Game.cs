using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_AI_Player.Classes
{
    public class Game
    {
        // Attributes
        private Player[] players;
        private Board game_board = new Board();
        int game_level;
        int comp1_level, comp2_level;
        private List<Pair<int, int>> valid_moves = new List<Pair<int, int>>();

        // Constructors
        public Game(Player[] players, int game_level)
        {
            this.players = players;
            this.game_level = game_level;
        }
        public Game(Player[] players, int comp1_level, int comp2_level)
        {
            this.players = players;
            this.comp1_level = comp1_level;
            this.comp2_level = comp2_level;
        }

        public List<Pair<int, int>> ValidMoves
        {
            get { return valid_moves; }
            set { valid_moves = value; }
        }

        public Board GameBoard
        {
            get { return game_board; }
            set { game_board = value; }
        }

        public int GameLevel
        {
            get { return game_level; }
            set { game_level = value; }
        }

        public int Comp1Level
        {
            get { return comp1_level; }
            set { comp1_level = value; }
        }

        public int Comp2Level
        {
            get { return comp2_level; }
            set { comp2_level = value; }
        }

        public Player[] PlayersArray
        {
            get { return players; }
            set { players = value; }
        }


        // Method to update the score of the players
        public void UpdateScore()
        {
            players[0].PlayerScore = game_board.CountWhite;
            players[1].PlayerScore = game_board.CountBlack;
        }

        // Method to make a move
        public void MakeMove(Player player, Pair<int, int> move)
        {
            game_board.UpdateBoard(player, move.First, move.Second);
            UpdateScore();
        }
    }
}
