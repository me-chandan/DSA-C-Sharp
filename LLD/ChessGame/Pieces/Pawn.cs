using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(bool isWhite) : base(isWhite, new PawnMovementStrategy())
        {
        }
    }
}