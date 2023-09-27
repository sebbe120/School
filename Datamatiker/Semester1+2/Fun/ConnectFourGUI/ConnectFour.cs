using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFourGUI
{
    public partial class ConnectFour : Form
    {
        public ConnectFour()
        {
            InitializeComponent();
            LabelMatrix();
        }

        // Initialize Connect Four board
        Board board = new Board();

        // Number of moves left in each column
        int[] movesLeftArray = new int[7] {5, 5, 5, 5, 5, 5, 5};

        // Matrix with labels for the board GUI
        Label[,] lblArray = new Label[6, 7];

        // PNG files with the pictures for the tokens
        Image player1PNG = Image.FromFile(Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")), "RedToken.png"));
        Image player2PNG = Image.FromFile(Path.Combine(Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\")), "YellowToken.png"));

        // Checks if the game is Won / is a Tie, and disables all buttons
        public void CheckGameState()
        {
            if (Logic.CheckWon(board))
            {
                lblDialog.Text = $"Player {board.GetPlayer()} Won!";
                DisableAllButtons();
                buttonRestart.Enabled = true;
                buttonRestart.Visible = true;
            }
            else if (Logic.CheckTie(board))
            {
                lblDialog.Text = "The game is a Tie!";
                DisableAllButtons();
                buttonRestart.Enabled = true;
                buttonRestart.Visible = true;
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            lblDialog.Text = $"Player {board.GetPlayer()} placed token in column 0";
            board.SetToken(movesLeftArray[0], 0);
            LabelPicture(0, board);
            movesLeftArray[0] -= 1;
            if (movesLeftArray[0] == -1)
            {
                button0.Enabled = false;
            }
            CheckGameState();
            board.ChangePlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblDialog.Text = $"Player {board.GetPlayer()} placed token in column 1";
            board.SetToken(movesLeftArray[1], 1);
            LabelPicture(1, board);
            movesLeftArray[1] -= 1;
            if (movesLeftArray[1] == -1)
            {
                button1.Enabled = false;
            }
            CheckGameState();
            board.ChangePlayer();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblDialog.Text = $"Player {board.GetPlayer()} placed token in column 2";
            board.SetToken(movesLeftArray[2], 2);
            LabelPicture(2, board);
            movesLeftArray[2] -= 1;
            if (movesLeftArray[2] == -1)
            {
                button2.Enabled = false;
            }
            CheckGameState();
            board.ChangePlayer();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblDialog.Text = $"Player {board.GetPlayer()} placed token in column 3";
            board.SetToken(movesLeftArray[3], 3);
            LabelPicture(3, board);
            movesLeftArray[3] -= 1;
            if (movesLeftArray[3] == -1)
            {
                button3.Enabled = false;
            }
            CheckGameState();
            board.ChangePlayer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lblDialog.Text = $"Player {board.GetPlayer()} placed token in column 4";
            board.SetToken(movesLeftArray[4], 4);
            LabelPicture(4, board);
            movesLeftArray[4] -= 1;
            if (movesLeftArray[4] == -1)
            {
                button4.Enabled = false;
            }
            CheckGameState();
            board.ChangePlayer();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            lblDialog.Text = $"Player {board.GetPlayer()} placed token in column 5";
            board.SetToken(movesLeftArray[5], 5);
            LabelPicture(5, board);
            movesLeftArray[5] -= 1;
            if (movesLeftArray[5] == -1)
            {
                button5.Enabled = false;
            }
            CheckGameState();
            board.ChangePlayer();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            lblDialog.Text = $"Player {board.GetPlayer()} placed token in column 6";
            board.SetToken(movesLeftArray[6], 6);
            LabelPicture(6, board);
            movesLeftArray[6] -= 1;
            if (movesLeftArray[6] == -1)
            {
                button6.Enabled = false;
            }
            CheckGameState();
            board.ChangePlayer();
        }

        // Initializes a matrix with the board
        public void LabelMatrix()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    Label lbl = new Label();
                    lbl.Name = "label" + row;
                    lblArray[row, column] = lbl;
                    lbl.AutoSize = false;
                    lbl.Font = new Font("Segoe UI", 18);
                    lbl.TextAlign = (ContentAlignment)32;
                    lbl.Location = new Point(49 + column * 100, 65 + row * 100);
                    lbl.Size = new Size(100, 100);
                    lbl.BackColor = Color.White;

                    Controls.Add(lbl);
                }
            }
        }

        // Draws tokens on the board
        public void LabelPicture(int column, Board board)
        {
            if (board.GetPlayer() == 1)
            {
                lblArray[movesLeftArray[column], column].Image = player1PNG;
            }
            else
            {
                lblArray[movesLeftArray[column], column].Image = player2PNG;
            }

        }

        // Resets the drawn tokens on the board
        public void ResetLabels()
        {
            foreach (Control c in Controls)
            {
                if (c is Label b)
                {
                    if (b == lblDialog)
                        continue;
                    b.Image = null;
                }
            }
        }

        public void DisableAllButtons()
        {
            foreach (Control c in Controls)
            {
                if (c is Button b)
                {
                    b.Enabled = false;
                }
            }
        }

        public void EnableAllButtons()
        {
            foreach (Control c in Controls)
            {
                if (c is Button b)
                {
                    b.Enabled = true;
                }
            }
        }        

        // Resets the game
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            // Reset objects
            board = new Board();
            movesLeftArray = new int[7] { 5, 5, 5, 5, 5, 5, 5 };
            ResetLabels();

            EnableAllButtons();
            buttonRestart.Enabled = false;
            buttonRestart.Visible = false;
            lblDialog.Text = "Player 1's turn";
        }
    }
}
