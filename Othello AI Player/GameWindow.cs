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
    public partial class GameWindow : Form
    {
        public Player[] players;
        public Player currentPlayer;
        public Game game;
        public PictureBoxBoard[,] PictureBoxBoard;
        private readonly Image black_image = Properties.Resources.bb;
        private readonly Image white_image = Properties.Resources.gg;

        public GameWindow()
        {
            game = new Game(players, 0);
            InitializeComponent();
            buildPictureBoxBoard();
            printGameBoard();
        }

        //-------------------------------------------- PictureBox methods ----------------------------------------//
        public void buildPictureBoxBoard()
        {
            int distanceFromLeft = 15;
            int distanceFromTop = 15;
            PictureBoxBoard = new PictureBoxBoard[Helper.board_size, Helper.board_size];
            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    PictureBoxBoard[i, j] = createPictureBox(i, j, distanceFromLeft, distanceFromTop);
                    this.Controls.Add(PictureBoxBoard[i, j]);
                    distanceFromLeft += 50;
                }
                distanceFromTop += 50;
                distanceFromLeft = 15;
            }
        }

        public PictureBoxBoard createPictureBox(int i_Row, int i_Col, int i_Left, int i_Top)
        {
            PictureBoxBoard pictureBoxButton = new PictureBoxBoard();
            pictureBoxButton.Height = 50;
            pictureBoxButton.Width = 50;
            pictureBoxButton.Left = i_Left;
            pictureBoxButton.Top = i_Top;
            pictureBoxButton.Row = i_Row;
            pictureBoxButton.Col = i_Col;
            pictureBoxButton.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxButton.BorderStyle = BorderStyle.Fixed3D;
            return pictureBoxButton;
        }

        public void printGameBoard()
        {
            clearGameBoard();
            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    if (game.GameBoard.ScreenBoard[i, j] == Position_Color.BLACK)
                    {
                        PictureBoxBoard[i, j].Image = black_image;
                    }
                    else if (game.GameBoard.ScreenBoard[i, j] == Position_Color.WHITE)
                    {
                        PictureBoxBoard[i, j].Image = white_image;
                    }
                    else
                    {
                        continue;
                    }
                    PictureBoxBoard[i, j].Enabled = true;
                }
            }
        }

        public void clearGameBoard()
        {
            for (int i = 0; i < Helper.board_size; i++)
            {
                for (int j = 0; j < Helper.board_size; j++)
                {
                    PictureBoxBoard[i, j].Enabled = false;
                    PictureBoxBoard[i, j].BackColor = Color.LightGray;
                    PictureBoxBoard[i, j].Image = null;
                }
            }
        }

        public void getWinner()
        {
            if (game.PlayersArray[0].PlayerScore < game.PlayersArray[1].PlayerScore)
            {
                getWinnerMessage(game.PlayersArray[1]);
            }
            else if (game.PlayersArray[0].PlayerScore > game.PlayersArray[1].PlayerScore)
            {
                getWinnerMessage(game.PlayersArray[0]);
            }
            else
            {
                getTieMessage();
            }
        }

        public void getTieMessage()
        {
            string message = string.Format(
@"Game ends in tie! 
Continue Playing?");

            endGame(message);
        }

        public void getWinnerMessage(Player i_Winner)
        {
            string message = string.Format(
@"{0} Won!!
Golden: {1}/{2} :Black
Continue Playing?",
                i_Winner.PlayerName,
                game.GameBoard.CountWhite,
                game.GameBoard.CountBlack);

            endGame(message);
        }

        public void endGame(string i_DialogMessage)
        {
            DialogResult dialogResult = MessageBox.Show(i_DialogMessage, "Othello Game", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                Application.Restart();
            }
            else if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
