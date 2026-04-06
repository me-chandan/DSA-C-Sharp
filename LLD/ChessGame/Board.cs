using ChessGame.Pieces;

namespace ChessGame
{
    public class Board
    {
        private int _row;
        private int _col;
        private Cell[][] _cells;

        private static Board _instance;

        private Board(int rows, int col)
        {
            _row = rows;
            _col = col;
            InitializeBoard();
        }

        public static Board GetInstance(int row, int col)
        {
            if( _instance == null)
            {
                return new Board(row, col);
            }
            return _instance;
        }

        public Cell GetCell(int row, int col)
        {
            return _cells[row][col];
        }

        private void InitializeBoard()
        {
            _cells = new Cell[_row][];
            for(int i = 0; i < _row; i++)
            {
                _cells[i] = new Cell[_col];
            }

            SetPieces(row: 0, isWhite: false);
            SetPieces(row: _row - 1, isWhite: true);

            SetPawns(row: 1, isWhite: false);
            SetPawns(row: _row - 2, isWhite: true);
        }

        private void SetPieces(int row, bool isWhite)
        {
            _cells[row][0].PlacePiece(PieceFactory.CreatePiece(PieceType.Rook, isWhite));
            _cells[row][1].PlacePiece(PieceFactory.CreatePiece(PieceType.Knight, isWhite));
            _cells[row][2].PlacePiece(PieceFactory.CreatePiece(PieceType.Bishop, isWhite));
            _cells[row][3].PlacePiece(PieceFactory.CreatePiece(PieceType.Queen, isWhite));
            _cells[row][4].PlacePiece(PieceFactory.CreatePiece(PieceType.King, isWhite));
            _cells[row][5].PlacePiece(PieceFactory.CreatePiece(PieceType.Bishop, isWhite));
            _cells[row][6].PlacePiece(PieceFactory.CreatePiece(PieceType.Knight, isWhite));
            _cells[row][7].PlacePiece(PieceFactory.CreatePiece(PieceType.Rook, isWhite));
        }

        private void SetPawns(int row, bool isWhite)
        {
            for(int i = 0; i < _col; i++)
            {
                _cells[row][i].PlacePiece(PieceFactory.CreatePiece(PieceType.Pawn, isWhite));
            }
        }
    }
}
