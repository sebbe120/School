using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048_WPF
{
    public class Board
    {
        private Piece[,] board;
        public readonly int rows;
        public readonly int columns;
        private int score = 0;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            board = new Piece[rows, columns];

            board[0, 0] = new Piece();
            board[1, 2] = new Piece();
        }

        public Piece this[int row, int column]
        {
            get => board[row, column];
            set => board[row, column] = value;
        }

        public int Score
        {
            get { return score; }
            private set { score = value; }
        }

        // Move pieces in the given direction
        public void MovePieces(string directionString)
        {
            switch (directionString)
            {
                case "Up":
                    MovePiecesUp();
                    break;
                case "Left":
                    MovePiecesLeft();
                    break;
                case "Right":
                    MovePiecesRight();
                    break;
                case "Down":
                    MovePiecesDown();
                    break;

                default:
                    break;
            }
        }

        public void MovePiecesUp()
        {
            // Start at row 1 column 0
            for (int row = 1; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    // Continue if there is no piece on this place
                    if (board[row, column] == null)
                    {
                        continue;
                    }

                    // Check if the row directly above contains a piece of the same type
                    if (board[row - 1, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row - 1, column].Value)
                        {
                            CollidePieces(row, column, row - 1, column, "Up");
                        }
                    }

                    // Check row 2 to row 0 above contains a piece of the same type
                    else if (row == 2 && board[row - 2, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row - 2, column].Value)
                        {
                            CollidePieces(row, column, row - 2, column, "Up");
                        }
                    }

                    // Check row 3 to row 1 above contains a piece of the same type
                    else if (row == 3 && board[row - 2, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row - 2, column].Value)
                        {
                            CollidePieces(row, column, row - 2, column, "Up");
                        }
                    }

                    // Check row 3 to row 0 above contains a piece of the same type
                    else if (row == 3 && board[row - 3, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row - 3, column].Value)
                        {
                            CollidePieces(row, column, row - 3, column, "Up");
                        }
                    }

                    MovetoHighestPosition(row, column);
                }
            }
        }

        public void MovetoHighestPosition(int currentRow, int currentColumn)
        {
            int newRow = -1;

            for (int row = currentRow - 1; row >= 0; row--)
            {
                if (this[row, currentColumn] == null)
                {
                    newRow = row;
                }

                else
                {
                    break;
                }
            }

            if (newRow > -1)
            {
                this[newRow, currentColumn] = this[currentRow, currentColumn];
                this[currentRow, currentColumn] = null;
            }
        }

        public void MovePiecesLeft()
        {
            // Start at row 0 column 1
            for (int row = 0; row < rows; row++)
            {
                for (int column = 1; column < columns; column++)
                {
                    // Continue if there is no piece on this place
                    if (board[row, column] == null)
                    {
                        continue;
                    }

                    // Check if the column directly to the left contains a piece of the same type
                    if (board[row, column - 1] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column - 1].Value)
                        {
                            CollidePieces(row, column, row, column - 1 , "Left");
                        }
                    }

                    // Check column 2 to column 0
                    else if (column == 2 && board[row, column - 2] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column - 2].Value)
                        {
                            CollidePieces(row, column, row, column - 2, "Left");
                        }
                    }

                    // Check column 3 to column 1
                    else if (column == 3 && board[row, column - 2] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column - 2].Value)
                        {
                            CollidePieces(row, column, row, column - 2, "Left");
                        }
                    }

                    // Check column 3 to column 0
                    else if (column == 3 && board[row, column - 3] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column - 3].Value)
                        {
                            CollidePieces(row, column, row, column - 3, "Left");
                        }
                    }

                    MovetoLeftMostPosition(row, column);
                }
            }
        }        

        private void MovetoLeftMostPosition(int currentRow, int currentColumn)
        {
            int newColumn = -1;

            for (int column = currentColumn - 1; column >= 0 ; column--)
            {
                if (this[currentRow, column] == null)
                {
                    newColumn = column;
                }

                else
                {
                    break;
                }
            }

            // If a lower position is available, move to that position
            if (newColumn > -1)
            {
                this[currentRow, newColumn] = this[currentRow, currentColumn];
                this[currentRow, currentColumn] = null;
            }
        }

        public void MovePiecesRight()
        {
            // Start at row 0 column 1
            for (int row = 0; row < rows; row++)
            {
                for (int column = 2; column >= 0; column--)
                {
                    // Continue if there is no piece on this place
                    if (board[row, column] == null)
                    {
                        continue;
                    }

                    // Check if the column directly to the right contains a piece of the same type
                    if (board[row, column + 1] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column + 1].Value)
                        {
                            CollidePieces(row, column, row, column + 1, "Right");
                        }
                    }

                    // Check column 1 to column 3
                    else if (column == 1 && board[row, column + 2] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column + 2].Value)
                        {
                            CollidePieces(row, column, row, column + 2, "Right");
                        }
                    }

                    // Check column 0 to column 2
                    else if (column == 0 && board[row, column + 2] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column + 2].Value)
                        {
                            CollidePieces(row, column, row, column + 2, "Right");
                        }
                    }

                    // Check column 0 to column 3
                    else if (column == 0 && board[row, column + 3] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row, column + 3].Value)
                        {
                            CollidePieces(row, column, row, column + 3, "Right");
                        }
                    }

                    MovetoRightMostPosition(row, column);
                }
            }
        }

        private void MovetoRightMostPosition(int currentRow, int currentColumn)
        {
            int newColumn = -1;

            for (int column = currentColumn + 1; column < columns; column++)
            {
                if (this[currentRow, column] == null)
                {
                    newColumn = column;
                }

                else
                {
                    break;
                }
            }

            // If a lower position is available, move to that position
            if (newColumn > -1)
            {
                this[currentRow, newColumn] = this[currentRow, currentColumn];
                this[currentRow, currentColumn] = null;
            }
        }

        public void MovePiecesDown()
        {
            // Start at row 2 column 0
            for (int row = rows - 2; row >= 0; row--)
            {
                for (int column = 0; column < columns; column++)
                {
                    // Continue if there is no piece on this place
                    if (board[row, column] == null)
                    {
                        continue;
                    }

                    // Check if the row directly below contains a piece of the same type
                    if (board[row + 1, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row + 1, column].Value)
                        {
                            CollidePieces(row, column, row + 1, column, "Down");
                        }
                    }

                    // Check row 1 to row 3 below contains a piece of the same type
                    else if (row == 1 && board[row + 2, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row + 2, column].Value)
                        {
                            CollidePieces(row, column, row + 2, column, "Down");
                        }
                    }

                    // Check row 0 to row 2 below contains a piece of the same type
                    else if (row == 0 && board[row + 2, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row + 2, column].Value)
                        {
                            CollidePieces(row, column, row + 2, column, "Down");
                        }
                    }

                    // Check row 0 to row 3 below contains a piece of the same type
                    else if (row == 0 && board[row + 3, column] != null)
                    {
                        // Check if the pieces have the same value
                        if (board[row, column].Value == board[row + 3, column].Value)
                        {
                            CollidePieces(row, column, row + 3, column, "Down");
                        }
                    }

                    MovetoLowestPosition(row, column);
                }
            }
        }

        public void MovetoLowestPosition(int currentRow, int currentColumn)
        {
            int newRow = -1;

            for (int row = currentRow + 1; row < rows; row++)
            {
                if (this[row, currentColumn] == null)
                {
                    newRow = row;
                }

                else
                {
                    break;
                }
            }

            // If a lower position is available, move to that position
            if (newRow > -1)
            {
                this[newRow, currentColumn] = this[currentRow, currentColumn];
                this[currentRow, currentColumn] = null;
            }
        }

        public void CollidePieces(int currentRow, int currentColumn, int otherRow, int otherColumn, string direction)
        {
            // Destroy moving piece
            this[currentRow, currentColumn] = null;

            // Upgrade static piece
            Piece newPiece = this[otherRow, otherColumn];
            newPiece.Upgrade();
            Score += newPiece.Value;
            this[otherRow, otherColumn] = newPiece;

            // Move to lowest position in the given direction
            switch (direction)
            {
                case "Up":
                    MovetoHighestPosition(otherRow, otherColumn);
                    break;
                case "Left":
                    MovetoLeftMostPosition(otherRow, otherColumn);
                    break;
                case "Right":
                    MovetoRightMostPosition(otherRow, otherColumn);
                    break;
                case "Down":
                    MovetoLowestPosition(otherRow, otherColumn);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Spawns a new piece if possible
        /// </summary>
        public void SpawnNewPiece()
        {
            if (IsGameBoardFull())
            {
                throw new InvalidOperationException();
            }

            List<(int, int)> positions = GetAvailablePositions();

            Random r = new Random();
            int val = r.Next(0, positions.Count);

            board[positions[val].Item1, positions[val].Item2] = new Piece();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns> List of empty spaces on the board</returns>
        List<(int, int)> GetAvailablePositions()
        {
            List<(int, int)> positions = new List<(int, int)>();

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (board[row, column] == null)
                    {
                        positions.Add((row, column));
                    }
                }
            }

            return positions;
        }

        /// <summary>
        /// Checks if the board is full
        /// </summary>
        /// <returns>bool</returns>
        bool IsGameBoardFull()
        {
            bool isFull = true;
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (board[row, column] == null)
                    {
                        isFull = false;
                        break;
                    }
                }

                if (!isFull)
                {
                    break;
                }
            }

            return isFull;
        }
    }
}
