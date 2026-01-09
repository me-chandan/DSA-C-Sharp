namespace TicTacToeV2
{
    public class HumanStrategy : IPlayerStrategy
    {
        public Position GetNextMove(Board board, Player player)
        {
            while (true)
            {
                Console.WriteLine($"{player.Name} with symbol: {player.Symbol}, enter your move (row and column): ");
                var input = Console.ReadLine();
                var parts = input?.Split(' ');
                if (parts?.Length == 2 &&
                    int.TryParse(parts[0], out int row) &&
                    int.TryParse(parts[1], out int column))
                {
                    var position = new Position(row, column);
                    if (board.IsValidMove(position))
                    {
                        return position;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. The cell is already occupied or out of bounds.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter row and column separated by a space.");
                }
            }
        }
    }
}
