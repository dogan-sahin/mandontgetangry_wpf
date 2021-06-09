using ManDontGetAngryGame.Enums;
using ManDontGetAngryGame.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ManDontGetAngryGame.ViewModels
{
    public class CellStatusViewModel : ICellStatusViewModel {

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private int _rowIndex;
        private int _colIndex;

        public CellStatusViewModel(int row, int col, int currentPos, ECellColor cellColor, ECellType cellType)
        {
            _colIndex = col;
            _rowIndex = row;
            _currentPos = currentPos;
            _cellColor = cellColor;
            _cellType = cellType;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int RowIndex
        {
            get { return _rowIndex; }
            set
            {
                if (_rowIndex != value)
                {
                    _rowIndex = value;
                    OnPropertyChanged(nameof(RowIndex));
                }
            }
        }

        private int _currentPos = 0;
        public int CurrentPosition
        {
            get { return _currentPos; }
            set
            {
                if (_currentPos != value)
                {
                    _currentPos = value;
                    OnPropertyChanged(nameof(CurrentPosition));
                }
            }
        }

        public int ColIndex
        {
            get { return _colIndex; }
            set
            {
                if (_colIndex != value)
                {
                    _colIndex = value;
                    OnPropertyChanged(nameof(ColIndex));
                }
            }
        }

        private ECellColor _cellColor = ECellColor.White;
        public ECellColor CellColor
        {
            get { return _cellColor; }
            set
            {
                if (_cellColor != value)
                {
                    _cellColor = value;
                    OnPropertyChanged(nameof(CellColor));
                }
            }
        }

        private EPieceColor _pieceColor = EPieceColor.None;
        public EPieceColor PieceColor
        {
            get { return _pieceColor; }
            set
            {
                if (_pieceColor != value)
                {
                    _pieceColor = value;
                    OnPropertyChanged(nameof(PieceColor));
                }
            }
        }

        private ECellType _cellType = ECellType.PlayingCell;
        public ECellType CellType
        {
            get { return _cellType; }
            set
            {
                if (_cellType != value)
                {
                    _cellType = value;
                    OnPropertyChanged(nameof(CellType));
                }
            }
        }

        public void SetPiece(EPieceColor piece)
        {
            PieceColor = piece;
        }

        public CellId Identifier
        {
            get { return CellId.Create(_currentPos, _cellColor, _cellType); }
        }

        public bool IsEmpty
        {
            get { return _pieceColor == EPieceColor.None; }
        }



    }
}
