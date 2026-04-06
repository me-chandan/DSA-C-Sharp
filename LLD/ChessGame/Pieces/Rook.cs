using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public class Rook : Piece
    {
        public Rook(bool isWhite) : base(isWhite, new RookMovementStrategy())
        {
        }
    }
}