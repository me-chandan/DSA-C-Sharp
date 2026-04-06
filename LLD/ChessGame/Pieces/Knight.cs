using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public class Knight : Piece
    {
        public Knight(bool isWhite) : base(isWhite, new KnightMovementStrategy())
        {
        }
    }
}