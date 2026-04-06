using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public abstract class Piece
    {
        public bool IsWhite { get; private set; }
        public bool IsKilled { get; private set; }

        private readonly IMovementStrategy _movementStrategy;

        protected Piece(bool isWhite, IMovementStrategy movementStrategy)
        {
            IsWhite = isWhite;
            _movementStrategy = movementStrategy;
        }

        public bool IsBlack()
        {
            return !IsWhite; 
        }

        public void SetKilled()
        {
            IsKilled = true;
        }

        public bool CanMove(Board board, Cell startCell, Cell endCell)
        {
            return _movementStrategy.CanMove(board, startCell, endCell);
        }
    }
}
