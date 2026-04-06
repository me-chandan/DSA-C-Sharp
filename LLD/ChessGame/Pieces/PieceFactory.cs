using ChessGame.PieceMovementStrategies;

namespace ChessGame.Pieces
{
    public class PieceFactory
    {
        public static Piece CreatePiece(PieceType pieceType, bool isWhite)
        {
            return pieceType switch
            {
                PieceType.Pawn => new Pawn(isWhite),
                PieceType.Knight => new Knight(isWhite),
                PieceType.Bishop => new Bishop(isWhite),
                PieceType.Rook => new Rook(isWhite),
                PieceType.Queen => new Queen(isWhite),
                PieceType.King => new King(isWhite),
                _ => throw new ArgumentException("Invalid piece type"),
            };
        }
    }
}
