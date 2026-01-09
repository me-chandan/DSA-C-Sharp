namespace TicTacToeV2
{
    public class DrawState : IGameState
    {
        public void Next(GameContext context, Player player, bool hasWon)
        {
            // Game is over, no further state transitions.
        }
        public bool IsGameOver()
        {
            return true;
        }
    }
}
