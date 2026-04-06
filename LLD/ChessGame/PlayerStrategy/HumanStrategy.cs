namespace ChessGame.PlayerStrategy
{
    public class HumanStrategy : IPlayerStrategy
    {
        public Move DetermineMove(Board board, bool isWhite, Player player)
        {
            string colour = isWhite ? "White" : "Black";
            Console.WriteLine($"{player.Name}'s turn ({colour}): ");

            //Ask for source cell
            Console.Write("Enter source cell (e.g., 6 4): ");
            string? sourceInput = Console.ReadLine();
            if (string.IsNullOrEmpty(sourceInput))
            {
                throw new ArgumentException("Invalid source cell input.");
            }
            var sourceParts = sourceInput.Split(' ');
            int sourceRow = int.Parse(sourceParts[0]);
            int sourceCol = int.Parse(sourceParts[1]);
            Cell sourceCell = board.GetCell(sourceRow, sourceCol);

            //Ask for destination cell
            Console.Write("Enter destination cell (e.g., 5 4): ");
            string? destInput = Console.ReadLine();
            if (string.IsNullOrEmpty(destInput))
            {
                throw new ArgumentException("Invalid destination cell input.");
            }
            var destParts = destInput.Split(' ');
            int destRow = int.Parse(destParts[0]);
            int destCol = int.Parse(destParts[1]);
            Cell destCell = board.GetCell(destRow, destCol);
            return new Move(sourceCell, destCell);
        }
    }
}
