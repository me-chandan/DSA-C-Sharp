namespace TicTacToeV2
{
    public class Player
    {
        public string Name { get; }
        public Symbol Symbol { get; }

        private IPlayerStrategy _strategy;
        public Player(string name, Symbol symbol, IPlayerStrategy strategy)
        {
            Name = name;
            Symbol = symbol;
            _strategy = strategy;
        }

        public Position GetNextMove(Board board)
        {
            return _strategy.GetNextMove(board, this);
        }
    }
}
