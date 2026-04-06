namespace TicTacToeV2
{
    public class TicTacToeGame : IBoardGames
    {
        private readonly Board _board;
        private readonly Player _player_X;
        private readonly Player _player_O;
        private Player _currentPlayer;
        private GameContext _context;

        public TicTacToeGame(IPlayerStrategy xPlayerStrategy, IPlayerStrategy oPlayerStrategy, int row, int col)
        {
            _board = new Board(row, col);
            _player_X = new Player("Chandan", Symbol.X, xPlayerStrategy);
            _player_O = new Player("HumanB", Symbol.O, oPlayerStrategy);
            _currentPlayer = _player_X;
            _context = new GameContext();
        }

        public void PlayGame()
        {
            do
            {
                _board.Display();
                Position move = _currentPlayer.GetNextMove(_board);
                _board.PlaceSymbol(move, _currentPlayer.Symbol);

                //check game state for current player
                _board.CheckGameState(_context, _currentPlayer);
                SwitchPlayer();
            } while (!_context.IsGameOver());
            AnnounceResult();
        }

        private void SwitchPlayer()
        {
            _currentPlayer = _currentPlayer == _player_X ? _player_O : _player_X;
        }

        private void AnnounceResult()
        {
            IGameState gameState = _context.GetCurrentState();
            if (gameState != null)
            {
                if(gameState is X_WonState x_WonState)
                {
                    Console.WriteLine("Player X wins!");
                }
                else if (gameState is O_WonState o_WonState)
                {
                    Console.WriteLine("Player O wins!");
                }
                else
                {
                    Console.WriteLine("It is a Draw!");
                }
            }
        }
    }
}
