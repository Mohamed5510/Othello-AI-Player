using Ex05.WindowsFormsUI;
using Othello_AI_Player.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Othello_AI_Player
{
    public partial class ZeroPlayersWindow : GameWindow
    {
        public ZeroPlayersWindow(int comp1_level, int comp2_level)
        {
            InitializeComponent();
            startNewGame(comp1_level, comp2_level);
        }

        private void startNewGame(int comp1_level, int comp2_level)
        {
            players = new Player[2];
            players[0] = new Player("Computer1", Position_Color.BLACK);
            players[1] = new Player("Computer2", Position_Color.WHITE);
            currentPlayer = players[0];
            game = new Game(players, comp1_level, comp2_level);
            printGameBoard();
            playGame();
        }

        private void playGame()
        {
            this.Text = string.Format("Othello - {0}'s turn", currentPlayer.PlayerName);
            if (GameRules.HasValidMoves(game, game.PlayersArray[0]) || GameRules.HasValidMoves(game, game.PlayersArray[1]))
            {
                if (hasValidMoveForCurrentPlayer())
                {
                    if (currentPlayer.PlayerName == "Computer1")
                    {
                        printGameBoard();
                        makeComputerMove(game.PlayersArray[0], game.Comp1Level);
                    }
                    else if(currentPlayer.PlayerName == "Computer2")
                    {
                        printGameBoard();
                        makeComputerMove(game.PlayersArray[1], game.Comp2Level);
                    }
                }
            }
            else
            {
                getWinner();
            }
        }

        private void makeComputerMove(Player pl, int level)
        {
            Update();
            Thread.Sleep(1000);

            switch (level)
            {
                case 0:
                    GameRules.GetValidMoves(game, currentPlayer);
                    var random = new Random();
                    int randomIndex = random.Next(0, game.ValidMoves.Count);
                    game.MakeMove(pl, game.ValidMoves[randomIndex]);
                    break;
                case 1:
                    GameRules.GetValidMoves_Heuristic1(game, currentPlayer);
                    game.MakeMove(pl, game.ValidMoves[0]);
                    break;
                case 2:
                    GameRules.GetValidMoves_Heuristic2(game, currentPlayer);
                    game.MakeMove(pl, game.ValidMoves[0]);
                    break;
                case 3:
                    GameRules.GetValidMoves_Heuristic3(game, currentPlayer);
                    game.MakeMove(pl, game.ValidMoves[0]);
                    break;
            }
            switchPlayer();
            playGame();
        }

        private void switchPlayer()
        {
            if (currentPlayer == game.PlayersArray[0])
            {
                currentPlayer = game.PlayersArray[1];
            }
            else
            {
                currentPlayer = game.PlayersArray[0];
            }
        }

        private bool hasValidMoveForCurrentPlayer()
        {
            bool hasValidMove = true;
            if (!GameRules.HasValidMoves(game, currentPlayer))
            {
                MessageBox.Show(string.Format("No more valid moves for {0}! Switch turns", currentPlayer.PlayerName));
                switchPlayer();
                this.Text = string.Format("Othello - {0}rs turn", currentPlayer.PlayerName);
                if (currentPlayer.PlayerName == "Computer1")
                {
                    printGameBoard();
                    makeComputerMove(game.PlayersArray[0], game.Comp1Level);
                }
                else if(currentPlayer.PlayerName == "Computer2")
                {
                    printGameBoard();
                    makeComputerMove(game.PlayersArray[1], game.Comp2Level);
                }
                hasValidMove = false;
            }
            return hasValidMove;
        }


    }
}
