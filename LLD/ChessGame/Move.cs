namespace ChessGame
{
    public class Move
    {
        public Cell StartCell { get; private set; }
        public Cell EndCell { get; private set; }

        public Move(Cell startCell, Cell endCell)
        {
            StartCell = startCell;
            EndCell = endCell;
        }

        public bool IsValidMove()
        {
            return !(this.StartCell.Piece.IsWhite == this.EndCell.Piece.IsWhite);
        }
    }
}
