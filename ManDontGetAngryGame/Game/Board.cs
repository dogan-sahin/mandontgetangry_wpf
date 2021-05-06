using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Events;
using ManDontGetAngryGame.Model;

namespace ManDontGetAngryGame.Game
{
    class Board : IGameBoard
    {

        private Dictionary<CellId, CellModel> _cells;

        public int NumRows {
            get { return 11; }
        }

        public int NumCols
        {
            get{ return 11; }
        }
        
        public event EventHandler<CellStatusChangedEventArgs> CellStatusChanged;
       
        public void InitializeBoard()
        {
            _cells = new Dictionary<CellId, CellModel>();
            for (int row = 0; row < NumRows; row++)
            {
                for (int col = 0; col < NumCols; col++)
                {
                    _cells.Add(keyFor(row, col), new CellModel(row, col));
                }
            }
            SetupBoard();
        }

        public void SetupBoard()
        {

        }

        public CellModel GetCell(CellId cellId)
        {
            return _cells[cellId];
        }

        public bool IsValidMove(CellId source, CellId target)
        {
            throw new NotImplementedException();
        }

        public void MovePiece(CellId source, CellId target)
        {
            throw new NotImplementedException();
        }

        public void SwapPiece(CellId source, CellId target)
        {
            throw new NotImplementedException();
        }

        public bool HasMoved(CellId cell)
        {
            throw new NotImplementedException();
        }

        private CellId keyFor(int row, int col)
        {
            return CellId.Create(row, col);
        }
    }
}
