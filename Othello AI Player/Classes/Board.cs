using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_AI_Player.Classes
{
    /*
     * Class Name: Board.
     * Description: class to implement game board.
     * Attributes: 
     */
    public class Board
    {
        // Attributes
        private Position_Color[,] board = new Position_Color[Helper.board_size, Helper.board_size];
        private int black_cnt;
        private int white_cnt;
        private int empty_cnt;

        // Constructor
        public Board()
        {
            for(int i = 0; i < Helper.board_size; i++)
            {
                for(int j = 0; j < Helper.board_size; j++)
                {
                    board[i, j] = Position_Color.EMPTY;
                }
            }
            board[3, 3] = Position_Color.WHITE;
            board[4, 4] = Position_Color.WHITE;
            board[4, 3] = Position_Color.BLACK;
            board[3, 4] = Position_Color.BLACK;
            black_cnt = 2;
            white_cnt = 2;
            empty_cnt = (8 * 8) - 4;
        }

        public int CountBlack
        {
            get { return black_cnt; }
            set { black_cnt = value; }
        } // count current number of blacks on the board

        public int CountWhite
        {
            get { return white_cnt; }
            set { white_cnt = value; }
        } // count current number of whites on the board

        public int CountEmpty
        {
            get { return empty_cnt; }
            set { empty_cnt = value; }
        }

        public Position_Color[,] ScreenBoard
        {
            get { return board; }
            set { board = value; }
        }

        // Method to update counters
        private void UpdateCounters()
        {
            black_cnt = 0;
            white_cnt = 0;
            empty_cnt = 0;
            for(int i = 0; i < Helper.board_size; i++)
            {
                for(int j = 0; j < Helper.board_size; j++)
                {
                    if (board[i, j] == Position_Color.BLACK)
                        black_cnt++;
                    else if (board[i, j] == Position_Color.WHITE)
                        white_cnt++;
                    else
                        empty_cnt++;
                }
            }    
        }

        // Method to update the board
        public void UpdateBoard(Player player, int row_index, int column_index)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (GameRules.hasPossibleToFlip(this.board, player, row_index, column_index, i, j))
                    {
                        this.board[row_index, column_index] = player.Sign;
                        int rowToChange = row_index + i;
                        int colToChange = column_index + j;

                        while (this.board[rowToChange, colToChange] != player.Sign)
                        {
                            this.board[rowToChange, colToChange] = player.Sign;
                            rowToChange += i;
                            colToChange += j;
                        }
                    }
                }
            }
            UpdateCounters();
        }
    }
}
