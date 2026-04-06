using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(bool isWhite) : base(isWhite, new BishopMovementStrategy())
        {
        }
    }
}
