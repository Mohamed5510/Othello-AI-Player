using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello_AI_Player.Classes
{
    internal static class GameRules
    {
        private static int[,] Heuristic_Level3 = new int[8, 8] { { 8, 1, 6, 6, 6, 6, 1, 8 }, { 1, 0, 3, 3, 3, 3, 0, 1 }, { 6, 3, 5, 4, 4, 5, 3, 6 }, { 6, 3, 4, 5, 5, 4, 3, 6 }, { 6, 3, 4, 5, 5, 4, 3, 6 }, { 6, 3, 5, 4, 4, 5, 3, 6 }, { 1, 0, 3, 3, 3, 3, 0, 1 }, { 8, 1, 6, 6, 6, 6, 1, 8 } };

        public static bool IsValidMove(Game game, Player player, int row, int col)
        {
            bool isValid = false;
            if (game.GameBoard.ScreenBoard[row, col] != Position_Color.EMPTY)
            {
                isValid = false;
            }
            else
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (!((i == 0) && (j == 0)) && hasPossibleToFlip(game.GameBoard.ScreenBoard, player, row, col, i, j))
                        {
                            isValid = true;
                        }
                    }
                }
            }

            return isValid;
        }

        public static int IsValidMove_Heuristic1(Game game, Player player, int row, int col, ref int returned_row, ref int returned_col)
        {

            int max_moves = 0, moves;
            if (game.GameBoard.ScreenBoard[row, col] != Position_Color.EMPTY)
            {
                max_moves = 0;
            }
            else
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        moves = hasPossibleToFlip_Heuristic1(game.GameBoard.ScreenBoard, player, row, col, i, j);

                        if (!((i == 0) && (j == 0)) && moves > 0)
                        {
                            if (moves > max_moves)
                            {
                                max_moves = moves;
                                returned_row = row;
                                returned_col = col;
                            }
                        }
                    }
                }
            }

            return max_moves;
        }
        public static int IsValidMove_Heuristic2(Game game, Player player, int row, int col, ref int returned_row, ref int returned_col)
        {

            int max_moves = 0, moves;
            if (game.GameBoard.ScreenBoard[row, col] != Position_Color.EMPTY)
            {
                max_moves = 0;
            }
            else
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        moves = hasPossibleToFlip_Heuristic1(game.GameBoard.ScreenBoard, player, row, col, i, j);

                        if (!((i == 0) && (j == 0)) && moves > 0)
                        {

                            max_moves += moves;
                            returned_row = row;
                            returned_col = col;

                        }
                    }
                }
            }

            return max_moves;
        }

        public static int IsValidMove_Heuristic3(Game game, Player player, int row, int col, ref int returned_row, ref int returned_col)
        {

            int max_moves = 0, moves;
            if (game.GameBoard.ScreenBoard[row, col] != Position_Color.EMPTY)
            {
                max_moves = 0;
            }
            else
            {
                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        moves = hasPossibleToFlip_Heuristic1(game.GameBoard.ScreenBoard, player, row, col, i, j);

                        if (!((i == 0) && (j == 0)) && moves > 0)
                        {

                            max_moves = moves + max_moves + Heuristic_Level3[row, col];
                            returned_row = row;
                            returned_col = col;

                        }
                    }
                }
            }

            return max_moves;
        }

        public static bool hasPossibleToFlip(Position_Color[,] board, Player player, int row, int col, int direction_row, int direction_col)
        {
            bool isPossible = true;
            int rowToCheck = row + direction_row;
            int colToCheck = col + direction_col;

            while (rowToCheck >= 0 && rowToCheck < Helper.board_size && colToCheck >= 0 &&
                colToCheck < Helper.board_size && (board[rowToCheck, colToCheck] == player.GetOpponentSign()))
            {
                rowToCheck += direction_row;
                colToCheck += direction_col;
            }
            if (rowToCheck < 0 || rowToCheck > Helper.board_size - 1 || colToCheck < 0 ||
                colToCheck > Helper.board_size - 1 || (rowToCheck - direction_row == row && colToCheck - direction_col == col) ||
                board[rowToCheck, colToCheck] != player.Sign)
            {
                isPossible = false;
            }
            return isPossible;
        }

        public static int hasPossibleToFlip_Heuristic1(Position_Color[,] board, Player player, int row, int col, int direction_row, int direction_col)
        {
            int flips = 0;
            int rowToCheck = row + direction_row;
            int colToCheck = col + direction_col;

            while (rowToCheck >= 0 && rowToCheck < Helper.board_size && colToCheck >= 0 &&
                colToCheck < Helper.board_size && (board[rowToCheck, colToCheck] == player.GetOpponentSign()))
            {
                flips++;
                rowToCheck += direction_row;
                colToCheck += direction_col;
            }
            if (rowToCheck < 0 || rowToCheck > Helper.board_size - 1 || colToCheck < 0 ||
                colToCheck > Helper.board_size - 1 || (rowToCheck - direction_row == row && colToCheck - direction_col == col) ||
                board[rowToCheck, colToCheck] != player.Sign)
            {
                flips = 0;
            }
            return flips;
        }

        public static void GetValidMoves(Game game, Player currentPlayer)
        {
            game.ValidMoves.Clear();

            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    if (IsValidMove(game, currentPlayer, i, j))
                    {
                        Pair<int, int> ValidMoveToAdd = new Pair<int, int>(i, j);
                        game.ValidMoves.Add(ValidMoveToAdd);
                    }
                }
            }
        }

        public static void GetValidMoves_Heuristic1(Game game, Player currentPlayer)
        {
            game.ValidMoves.Clear();
            int row = 0;
            int col = 0;
            int max_moves = 0, moves;
            Pair<int, int> ValidMoveToAdd = new Pair<int, int>(-1, -1);
            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    moves = IsValidMove_Heuristic1(game, currentPlayer, i, j, ref row, ref col);
                    if (moves > 0)
                    {
                        if (moves > max_moves)
                        {
                            max_moves = moves;
                            ValidMoveToAdd = new Pair<int, int>(i, j);
                        }
                    }
                }
            }
            game.ValidMoves.Add(ValidMoveToAdd);
        }
        public static void GetValidMoves_Heuristic2(Game game, Player currentPlayer)
        {
            game.ValidMoves.Clear();
            int row = 0;
            int col = 0;
            int max_moves = 0, moves;
            Pair<int, int> ValidMoveToAdd = new Pair<int, int>(-1, -1);
            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    moves = IsValidMove_Heuristic2(game, currentPlayer, i, j, ref row, ref col);
                    if (moves > 0)
                    {
                        if (moves > max_moves)
                        {
                            max_moves = moves;
                            ValidMoveToAdd = new Pair<int, int>(i, j);
                        }
                    }
                }
            }
            game.ValidMoves.Add(ValidMoveToAdd);
        }
        public static void GetValidMoves_Heuristic3(Game game, Player currentPlayer)
        {
            game.ValidMoves.Clear();
            int row = 0;
            int col = 0;
            int max_moves = 0, moves;
            Pair<int, int> ValidMoveToAdd = new Pair<int, int>(-1, -1);
            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    moves = IsValidMove_Heuristic3(game, currentPlayer, i, j, ref row, ref col);
                    if (moves > 0)
                    {
                        if (moves > max_moves)
                        {
                            max_moves = moves;
                            ValidMoveToAdd = new Pair<int, int>(i, j);
                        }
                    }
                }
            }
            game.ValidMoves.Add(ValidMoveToAdd);
        }

        public static bool HasValidMoves(Game game, Player i_Player)
        {
            bool isValid = false;

            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    if (IsValidMove(game, i_Player, i, j))
                    {
                        isValid = true;
                    }
                }
            }

            return isValid;
        }

    }
}
