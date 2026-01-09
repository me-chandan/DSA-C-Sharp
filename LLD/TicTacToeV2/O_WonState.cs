namespace TicTacToeV2
{
    public class O_WonState : IGameState
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
