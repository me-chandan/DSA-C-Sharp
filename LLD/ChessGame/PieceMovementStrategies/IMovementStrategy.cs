namespace ChessGame.PieceMovementStrategies
{
    public interface IMovementStrategy
    {
        bool CanMove(Board board, Cell start, Cell end);
    }
}
