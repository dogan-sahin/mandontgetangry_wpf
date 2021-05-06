using ManDontGetAngryGame.Enums;

namespace ManDontGetAngryGame.Models
{
    class MdgACellModel
    {
        
        public ECellColor CellColor { get; private set; }
        public EPieceColor PieceColor { get; private set; }

        public ECellType CellType { get; private set; }

        public int RowIndex { get; }
        public int ColIndex { get; }

        public MdgACellModel(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColIndex = colIndex;
            CellColor = ECellColor.None;
            PieceColor = EPieceColor.None;
            CellType = ECellType.None;
        }

        public void SetPiece(EPieceColor pieceColor)
        {
            PieceColor = pieceColor;
        }

        public CellID CreateCellIdentifier => (CellID.CreateCellId(RowIndex, ColIndex));
    }
}
