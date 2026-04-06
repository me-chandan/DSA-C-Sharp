using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public class Queen : Piece
    {
        public Queen(bool isWhite) : base(isWhite, new QueenMovementStrategy())
        {
        }
    }
}
