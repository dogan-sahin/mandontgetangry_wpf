using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Enums;

namespace ManDontGetAngryGame.Model
{
    public class CellModel
    {
        public int RowIndex { get; }
        public int ColIndex { get; }
       public ECellType CellType { get; private set; }

       public EPieceColor PieceColor { get; private set; }

       public ECellColor CellColor { get; private set; }

        public CellModel(int row, int col, ECellType cellType, ECellColor cellColor)
        {
            RowIndex = row;
            ColIndex = col;
            CellType = cellType;
            CellColor = cellColor;
            PieceColor = EPieceColor.None;
        }

        public void SetPiece(EPieceColor color)
        {
            PieceColor = color;
        }

        public CellId Identifier
        {
            get { return CellId.Create(RowIndex, ColIndex); }
        }
    }
}
