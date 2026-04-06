using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public class King : Piece
    {
        public King(bool isWhite) : base(isWhite, new KingMovementStrategy())
        {
        }
    }
}
