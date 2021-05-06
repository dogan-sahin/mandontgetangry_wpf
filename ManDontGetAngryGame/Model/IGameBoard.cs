using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Events;

namespace ManDontGetAngryGame.Model
{
    interface IGameBoard
    {
        int NumRows { get; }

        int NumCols { get; }

       event EventHandler<CellStatusChangedEventArgs> CellStatusChanged;

        void InitializeBoard();

        CellModel GetCell(CellId cellId);

        bool IsValidMove(CellId source, CellId target);

        void MovePiece(CellId source, CellId target);

        void SwapPiece(CellId source, CellId target);

        bool HasMoved(CellId cell);
    }
}
