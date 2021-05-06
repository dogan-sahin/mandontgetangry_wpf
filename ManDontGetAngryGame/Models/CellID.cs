using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManDontGetAngryGame.Models
{
    class CellID
    {

        private int _rowCord;
        private int _colCord;

        public CellID(int rowCord, int colCord)
        {
            _rowCord = rowCord;
            _colCord = colCord;
        }

        public int RowCord => _rowCord;

        public int ColCord => _colCord;

        public static CellID CreateCellId(int rowCord, int colCord)
        {
            return new CellID(rowCord, colCord);
        }
    }
}
