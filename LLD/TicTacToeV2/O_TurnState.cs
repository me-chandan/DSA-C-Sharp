namespace TicTacToeV2
{
    public class O_TurnState : IGameState
    {
        public void Next(GameContext context, Player player, bool hasWon)
        {
            if (player == null)
            {
                context.SetState(new DrawState());
            }
            else if (hasWon)
            {
                IGameState state = player.Symbol == Symbol.X ? new X_WonState() : new O_WonState();
                context.SetState(state);
            }
            else
            {
                context.SetState(new X_TurnState());
            }
        }
        public bool IsGameOver()
        {
            return false;
        }
    }
}
