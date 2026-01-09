namespace TicTacToeV2
{
    public interface IPlayerStrategy
    {
        Position GetNextMove(Board board, Player player);
    }
}
