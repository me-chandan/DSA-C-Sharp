namespace ChessGame.PlayerStrategy
{
    public interface IPlayerStrategy
    {
        Move DetermineMove(Board board, bool isWhite, Player player);
    }
}
