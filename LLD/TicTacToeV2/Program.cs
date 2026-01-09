namespace TicTacToeV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //IPlayerStrategy humanStrategy1 = new HumanStrategy();
            //IPlayerStrategy humanStrategy2 = new HumanStrategy();
            //TicTacToeGame game = new TicTacToeGame(humanStrategy1, humanStrategy2, 3, 3);
            //game.PlayGame();
            IPlayerStrategy humanStrategy1 = new HumanStrategy();
            IPlayerStrategy aiStrategy = new AIStrategy();
            TicTacToeGame game = new TicTacToeGame(humanStrategy1, aiStrategy, 3, 3);
            game.PlayGame();
        }
    }
}
