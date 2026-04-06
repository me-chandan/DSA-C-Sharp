using ChessGame.Pieces;

namespace ChessGame
{
    public class Cell
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public string Label { get; private set; }
        public Piece? Piece { get; private set; }

        public Cell(int row, int column, string label)
        {
            Row = row;
            Column = column;
            Label = label;
        }

        public void PlacePiece(Piece piece)
        {
            this.Piece = piece;
        }
    }
}
