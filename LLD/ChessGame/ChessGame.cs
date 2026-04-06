using ChessGame.Pieces;

namespace ChessGame
{
    public class ChessGame : IBoardGame
    {
        private readonly Player _player1;
        private readonly Player _player2;
        private readonly Board _board;

        private bool _isWhiteTurn;
        private List<Move> _gameLog;
        private Status status;
        public ChessGame(Player player1, Player player2, int row, int col)
        {
            _player1 = player1;
            _player2 = player2;
            _board = Board.GetInstance(row, col);
            _isWhiteTurn = true;
            _gameLog = new List<Move>();
            status = Status.Ongoing;
        }
        public void PlayGame()
        {
            while (status == Status.Ongoing)
            {
                Player currentPlayer = _isWhiteTurn ? _player1 : _player2;
                Move move = currentPlayer.DetermineMove(_board, _isWhiteTurn);

                if (move == null || move.StartCell == null || move.StartCell.Piece == null)
                {
                    Console.WriteLine("Move or StartCell or Piece cannot be null");
                    continue;
                }

                if (move.IsValidMove())
                {
                    ExecuteMove(move);
                    _gameLog.Add(move);
                    _isWhiteTurn = !_isWhiteTurn;
                    UpdateGameStatus();
                }
                else
                {
                    Console.WriteLine("Invalid move. Try again.");
                }
            }


        }

        private void ExecuteMove(Move move)
        {
            Piece pieceToMove = move.StartCell.Piece;
            if (move.EndCell.Piece != null)
            {
                move.EndCell.Piece.SetKilled();
            }
            move.EndCell.PlacePiece(pieceToMove);
            move.StartCell.RemovePiece();
        }

        private void UpdateGameStatus()
        {
            // Simplified status update logic for demonstration purposes
            // In a real chess game, this would involve checking for check, checkmate, stalemate, etc.
            bool whiteKingAlive = false;
            bool blackKingAlive = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Cell cell = _board.GetCell(i, j);
                    if (cell.Piece is King king)
                    {
                        if (king.IsWhite && !king.IsKilled)
                        {
                            whiteKingAlive = true;
                        }
                        else if (!king.IsWhite && !king.IsKilled)
                        {
                            blackKingAlive = true;
                        }
                    }
                }
            }
            if (!whiteKingAlive)
            {
                status = Status.BlackWon;
                Console.WriteLine("Black wins!");
            }
            else if (!blackKingAlive)
            {
                status = Status.WhiteWon;
                Console.WriteLine("White wins!");
            }
        }
    }
}
