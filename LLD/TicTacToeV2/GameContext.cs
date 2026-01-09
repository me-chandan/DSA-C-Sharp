namespace TicTacToeV2
{
    public class GameContext
    {
        private IGameState _currentState;
        public GameContext()
        {
            _currentState = new X_TurnState();  // X starts first
        }
        public void SetState(IGameState newState)
        {
            _currentState = newState;
        }
        public void Next(Player player, bool hasWon)
        {
            _currentState.Next(this, player, hasWon);
        }
        public bool IsGameOver()
        {
            return _currentState.IsGameOver();
        }

        public IGameState GetCurrentState()
        {
            return _currentState;
        }
    }
}
