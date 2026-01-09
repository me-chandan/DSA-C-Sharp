namespace TicTacToeV2
{
    public interface IGameState
    {
        void Next(GameContext context, Player player, bool hasWon);
        bool IsGameOver();
    }
}
