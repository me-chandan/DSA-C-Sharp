namespace TicTacToeV2
{
    public class AIStrategy : IPlayerStrategy
    {
        public Position GetNextMove(Board board, Player player)
        {
            // Simple AI: Choose the first available cell
            Console.WriteLine($"{player.Name} with symbol: {player.Symbol} is making a move...");
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    var position = new Position(row, col);
                    if (board.IsValidMove(position))
                    {
                        return position;
                    }
                }
            }
            throw new InvalidOperationException("No valid moves available.");
        }
    }
}
