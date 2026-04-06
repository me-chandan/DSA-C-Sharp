using ChessGame.PlayerStrategy;

namespace ChessGame
{
    public class Player
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        private readonly IPlayerStrategy _playerStrategy;

        public Player(int id, string name, IPlayerStrategy playerStrategy)
        {
            this.Id = id;
            this.Name = name;
            _playerStrategy = playerStrategy;
        }

        public Move DetermineMove(Board board, bool isWhite)
        {
            return _playerStrategy.DetermineMove(board, isWhite, this);
        }
    }
}
