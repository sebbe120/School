using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace TicTacToeGUI
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
        }

        // Initialize TicTacToe board
        Board board = new Board(3);

        // Checks if the game is Won / is a Tie, and disables all buttons
        public void CheckGameState()
        {
            if (board.CheckWin())
            {
                if (board.IsTie)
                    lblDialog.Text = "The game is a Tie!";
                else
                    lblDialog.Text = $"Player {board.GetToken()} Won!";
                DisableAllButtons();
                buttonRestart.Enabled = true;
                buttonRestart.Visible = true;
                InvisibleLabels();
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

        public void InvisibleLabels()
        {
            foreach (Control c in Controls)
            {
                if (c is Label b)
                {
                    if (b == lblDialog)
                        continue;
                    b.Visible = false;
                }
            }
        }

        private void button00_Click(object sender, EventArgs e)
        {
            label00.Text = board.GetToken();
            label00.Visible = true;
            button00.Enabled = false;
            board.SetValue(0, 0);
            lblDialog.Text = $"Placed {board.GetToken()} at 0, 0!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button01_Click(object sender, EventArgs e)
        {
            label01.Text = board.GetToken();
            label01.Visible = true;
            button01.Enabled = false;
            board.SetValue(0, 1);
            lblDialog.Text = $"Placed {board.GetToken()} at 0, 1!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button02_Click(object sender, EventArgs e)
        {
            label02.Text = board.GetToken();
            label02.Visible = true;
            button02.Enabled = false;
            board.SetValue(0, 2);
            lblDialog.Text = $"Placed {board.GetToken()} at 0, 2!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label10.Text = board.GetToken();
            label10.Visible = true;
            button10.Enabled = false;
            board.SetValue(1, 0);
            lblDialog.Text = $"Placed {board.GetToken()} at 1, 0!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label11.Text = board.GetToken();
            label11.Visible = true;
            button11.Enabled = false;
            board.SetValue(1, 1);
            lblDialog.Text = $"Placed {board.GetToken()} at 1, 1!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label12.Text = board.GetToken();
            label12.Visible = true;
            button12.Enabled = false;
            board.SetValue(1, 2);
            lblDialog.Text = $"Placed {board.GetToken()} at 1, 2!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            label20.Text = board.GetToken();
            label20.Visible = true;
            button20.Enabled = false;
            board.SetValue(2, 0);
            lblDialog.Text = $"Placed {board.GetToken()} at 2, 0!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            label21.Text = board.GetToken();
            label21.Visible = true;
            button21.Enabled = false;
            board.SetValue(2, 1);
            lblDialog.Text = $"Placed {board.GetToken()} at 2, 1!";
            CheckGameState();
            board.ChangePlayer();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            label22.Text = board.GetToken();
            label22.Visible = true;
            button22.Enabled = false;
            board.SetValue(2, 2);
            lblDialog.Text = $"Placed {board.GetToken()} at 2, 2!";
            CheckGameState();
            board.ChangePlayer();
        }

        // Restarts the game
        private void buttonRestart_Click(object sender, EventArgs e)
        {
            board = new Board(3);
            EnableAllButtons();
            buttonRestart.Enabled = false;
            buttonRestart.Visible = false;
            lblDialog.Text = "Player O's turn";
        }
    }
}
