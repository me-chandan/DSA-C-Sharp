using System.Drawing;

namespace TicTacToeV2
{
    public class Board
    {
        private readonly Symbol[][] _grid;
        private readonly int _row;
        private readonly int _col;
        public Board(int row, int col)
        {
            _row = row;
            _col = col;
            _grid = new Symbol[row][];
            for (int i = 0; i < row; i++)
            {
                _grid[i] = new Symbol[col];
                for (int j = 0; j < col; j++)
                {
                    _grid[i][j] = Symbol.Empty;
                }
            }
        }
        public bool IsValidMove(Position position)
        {
            int row = position.Row;
            int col = position.Column;
            return row >= 0 && row < _row &&
                   col >= 0 && col < _col &&
                   _grid[row][col] == Symbol.Empty;
        }

        public void PlaceSymbol(Position position, Symbol symbol)
        {
            _grid[position.Row][position.Column] = symbol;
        }

        public void CheckGameState(GameContext context, Player currentPlayer)
        {
            // Check rows
            for (int i = 0; i < _grid.Length; i++)
            {
                if (_grid[i][0] != Symbol.Empty && IsWinningLine(_grid[i]))
                {
                    context.Next(currentPlayer, true);
                    return;
                }
            }

            // Check columns
            for (int j = 0; j < _col; j++)
            {
                Symbol[] column = new Symbol[_row];
                for (int i = 0; i < _row; i++)
                {
                    column[i] = _grid[i][j];
                }
                if (IsWinningLine(column))
                {
                    context.Next(currentPlayer, true);
                    return;
                }
            }

            // Check diagonals
            Symbol[] diagonal1 = new Symbol[_row];
            Symbol[] diagonal2 = new Symbol[_row];
            for (int i = 0; i < _row; i++)
            {
                diagonal1[i] = _grid[i][i];
                diagonal2[i] = _grid[i][_col - i - 1];
            }
            if (IsWinningLine(diagonal1) || IsWinningLine(diagonal2))
            {
                context.Next(currentPlayer, true);
                return;
            }

            // Check for draw
            bool isDraw = true;
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    if (_grid[i][j] == Symbol.Empty)
                    {
                        isDraw = false;
                        break;
                    }
                }
                if (!isDraw) break;
            }
            if (isDraw)
            {
                context.Next(null, false);
                return;
            }
        }

        private bool IsWinningLine(Symbol[] line)
        {
            Symbol first = line[0];
            if (first == Symbol.Empty) return false;
            foreach (var symbol in line)
            {
                if (symbol != first) return false;
            }
            return true;
        }

        public void Display()
        {
            for (int i = 0; i < _row; i++)
            {
                for (int j = 0; j < _col; j++)
                {
                    if (_grid[i][j] != Symbol.Empty)
                    {
                        Console.Write(_grid[i][j] + "   ");
                    }
                    else
                    {
                        Console.Write("    ");

                    }
                    Console.Write(" | ");
                }
                Console.WriteLine();

            }
        }
    }
}
