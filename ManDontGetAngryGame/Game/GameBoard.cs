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

        public GameBoard()
        {

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
            SetPiece(1, ECellColor.Blue, ECellType.PlayingCell, EPieceColor.Blue);

            SetPiece(1, ECellColor.Green, ECellType.HomeCell, EPieceColor.Green);
            SetPiece(2, ECellColor.Green, ECellType.HomeCell, EPieceColor.Green);
            SetPiece(3, ECellColor.Green, ECellType.HomeCell, EPieceColor.Green);
            SetPiece(13, ECellColor.Green, ECellType.PlayingCell, EPieceColor.Green);
        }

        public CellModel GetCell(CellId cellId)
        {
            return _cells[cellId];
        }

        public CellModel GetPlayingCell(int pos)
        {
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

        private CellId keyFor(int pos, ECellColor cellColor, ECellType cellType)
        {
            return CellId.Create(pos, cellColor, cellType);
        }

        public CellModel GetPieceFromHome(EPieceColor color)
        {
            return _cells.First;
        }

        public void MovePiece(CellId source, CellId target)
        {
            var piece = _cells[source].PieceColor;
            SetPiece(target, piece);
            SetPiece(source, EPieceColor.None);
        }

        public void ThrowPiece(CellId source, CellId target)
        {
            var piece1 = _cells[source].PieceColor;
            var piece2 = _cells[target].PieceColor;

            SetPiece(target, piece1);
            SetPiece(source, piece2);
        }

    }
}
