using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Enums;
using ManDontGetAngryGame.Events;
using ManDontGetAngryGame.Model;

namespace ManDontGetAngryGame.Game
{
    public class GameBoard
    {

        private Dictionary<CellId, CellModel> _cells;

        public Dictionary<CellId, CellModel> Cells
        {
            get { return _cells; }
        }

        public int NumRows {
            get { return 11; }
        }

        public int NumCols
        {
            get{ return 11; }
        }

        private int _totalPlayPositions = 24;

        public int TotalPlayPositions
        {
            get { return _totalPlayPositions; }
        }

        public event EventHandler<CellStatusChangedEventArgs> CellStatusChanged;
       
        public void InitializeBoard()
        {
            _cells = new Dictionary<CellId, CellModel>();
            foreach (var item in CellPositions.Positions)
            {
                _cells.Add(keyFor(item.Key.Item1, item.Key.Item2, item.Key.Item3),new CellModel(item.Value.Item1, item.Value.Item2, item.Key.Item1, item.Key.Item2, item.Key.Item3));
            }
            SetupBoard();
        }

        private void SetupBoard()
        {
            SetPiece(1, ECellColor.Blue, ECellType.HomeCell, EPieceColor.Blue);
            SetPiece(2, ECellColor.Blue, ECellType.HomeCell, EPieceColor.Blue);
            SetPiece(3, ECellColor.Blue, ECellType.HomeCell, EPieceColor.Blue);
            SetPiece(4, ECellColor.Blue, ECellType.HomeCell, EPieceColor.Blue);

            SetPiece(1, ECellColor.Green, ECellType.HomeCell, EPieceColor.Green);
            SetPiece(2, ECellColor.Green, ECellType.HomeCell, EPieceColor.Green);
            SetPiece(3, ECellColor.Green, ECellType.HomeCell, EPieceColor.Green);
            SetPiece(4, ECellColor.Green, ECellType.HomeCell, EPieceColor.Green);

            SetStartPiece(EPieceColor.Blue);
            SetStartPiece(EPieceColor.Green);

        }

        public CellModel GetCell(CellId cellId)
        {
            return _cells[cellId];
        }

        public void SetStartPiece(EPieceColor pieceColor)
        {
            if (pieceColor == EPieceColor.Blue)
            {
                MovePiece(GetPieceFromHome(ECellColor.Blue), GetStartCell(EPieceColor.Blue));
            } else if (pieceColor == EPieceColor.Green)
            {
                MovePiece(GetPieceFromHome(ECellColor.Green), GetStartCell(EPieceColor.Green));
            }
        }

        public CellModel GetPlayingCell(int pos)
        {
            if (pos == 0)
            {
                pos = 1;
            }
            if (pos == GetStartCell(EPieceColor.Blue).Position)
            {
                return GetCell(GetStartCell(EPieceColor.Blue));
            }
            else if (pos == GetStartCell(EPieceColor.Green).Position)
            {
                return GetCell(GetStartCell(EPieceColor.Green));
            }
            return _cells[keyFor(pos,ECellColor.White,ECellType.PlayingCell)];
        }

        public void SetPiece(CellId identifier, EPieceColor piece)
        {
            EPieceColor oldPiece = _cells[identifier].PieceColor;
            _cells[identifier].SetPiece(piece);
            CellStatusChanged(this, new CellStatusChangedEventArgs(identifier, oldPiece, piece));
        }

        public void SetPiece(int pos, ECellColor color, ECellType type, EPieceColor piece)
        {
            SetPiece(keyFor(pos, color, type), piece);
        }

        public CellId keyFor(int pos, ECellColor cellColor, ECellType cellType)
        {
            return CellId.Create(pos, cellColor, cellType);
        }

        public CellId GetPieceFromHome(ECellColor color)
        {
            try
            {
                if (color == ECellColor.Blue)
                {
                    return _cells.First(cellId =>
                        cellId.Key.Color == color && cellId.Key.Type == ECellType.HomeCell && cellId.Value.PieceColor == EPieceColor.Blue).Key;
                }
                return _cells.First(cellId =>
                    cellId.Key.Color == color && cellId.Key.Type == ECellType.HomeCell && cellId.Value.PieceColor == EPieceColor.Green).Key;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
            
        }

        public CellId GetStartCell(EPieceColor color)
        {
            if(color == EPieceColor.Blue)
            {
                return keyFor(1, ECellColor.Blue, ECellType.PlayingCell);
            }
            return keyFor(13, ECellColor.Green, ECellType.PlayingCell);
        }


        public CellId GetFreeEndCell(EPieceColor sourcePieceColor)
        {
            if (sourcePieceColor == EPieceColor.Blue)
            {
                return _cells.First(cellId =>
                    cellId.Key.Color == ECellColor.Blue && cellId.Key.Type == ECellType.EndCell && cellId.Value.PieceColor == EPieceColor.None).Key;
            }
            return _cells.First(cellId =>
                cellId.Key.Color == ECellColor.Green && cellId.Key.Type == ECellType.EndCell && cellId.Value.PieceColor == EPieceColor.None).Key;
        }


        public CellId GetLastPlayingCell(EPieceColor color)
        {
            if (color == EPieceColor.Blue)
            {
                return keyFor(24, ECellColor.White, ECellType.PlayingCell);
            }
            return keyFor(12, ECellColor.White, ECellType.PlayingCell);
        }
    

        public void MovePiece(CellId source, CellId target)
        {
            var piece = _cells[source].PieceColor;
            SetPiece(target, piece);
            SetPiece(source, EPieceColor.None);
        }


    }
}
