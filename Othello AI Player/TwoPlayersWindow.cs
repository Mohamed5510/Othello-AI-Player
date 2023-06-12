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
using System.Windows.Forms;

namespace Othello_AI_Player
{
    public partial class TwoPlayersWindow : GameWindow
    {
        public TwoPlayersWindow()
        {
            InitializeComponent();
            startNewGame();
        }

        private void startNewGame()
        {
            players = new Player[2];
            players[0] = new Player("Golden", Position_Color.WHITE);
            players[1] = new Player("Black", Position_Color.BLACK);
            currentPlayer = players[0];
            game = new Game(players, 0);
            printGameBoard();
            playGame();
        }

        private void playGame()
        {
            setValidMoves();
            this.Text = string.Format("Othello - {0}'s turn", currentPlayer.PlayerName);
            if (GameRules.HasValidMoves(game, game.PlayersArray[0]) || GameRules.HasValidMoves(game, game.PlayersArray[1]))
            {
                if (!hasValidMoveForCurrentPlayer())
                {
                    setValidMoves();
                }
            }
            else
            {
                getWinner();
            }
        }

        private void setValidMoves()
        {
            GameRules.GetValidMoves(game, currentPlayer);
            resetClicksOnBoard();
            printGameBoard();
            int i, j;
            foreach (Pair<int, int> pr in game.ValidMoves)
            {
                i = pr.First;
                j = pr.Second;
                PictureBoxBoard[i, j].Enabled = true;
                PictureBoxBoard[i, j].BackColor = Color.MediumSeaGreen;
                PictureBoxBoard[i, j].Click += new EventHandler(this.buttonPictureBox_Click);
            }
        }

        private void buttonPictureBox_Click(object sender, EventArgs e)
        {
            PictureBoxBoard selectedMove = sender as PictureBoxBoard;
            makePlayerMove(selectedMove);
        }

        private void resetClicksOnBoard()
        {
            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    PictureBoxBoard[i, j].Click -= new EventHandler(this.buttonPictureBox_Click);
                }
            }
        }

        private void makePlayerMove(PictureBoxBoard i_PictureBoxSelected)
        {
            string move = string.Empty;
            move += Convert.ToChar(i_PictureBoxSelected.Col + 'A');
            move += (i_PictureBoxSelected.Row + 1).ToString();
            int col = move[0] - 'A';
            int row = int.Parse(move[1].ToString());
            if (move.Length > 2)
            {
                row = ((row * 10) + int.Parse(move[2].ToString())) - 1;
            }
            else
            {
                row -= 1;
            }
            Pair<int, int> pr = new Pair<int, int>(row, col);
            game.MakeMove(currentPlayer, pr);
            switchPlayer();
            playGame();
        }

        private void switchPlayer()
        {
            if (currentPlayer.PlayerName == "Golden")
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
                this.Text = string.Format("Othello - {0}'s turn", currentPlayer.PlayerName);
                hasValidMove = false;
            }
            return hasValidMove;
        }

    }
}
