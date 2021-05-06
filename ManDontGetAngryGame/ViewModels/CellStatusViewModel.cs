using System;
using System.ComponentModel;
using ManDontGetAngryGame.Enums;
using ManDontGetAngryGame.Model;

namespace ManDontGetAngryGame.ViewModels
{
    public class CellStatusViewModel : ICellStatusViewModel
    {
        private readonly ECellType _cellType;
        private int _rowIndex;
        private int _colIndex;

        public CellStatusViewModel(ECellType cellType, int rowIndex, int colIndex)
        {
            _cellType = cellType;
            _rowIndex = rowIndex;
            _colIndex = colIndex;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate{};

        public virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        


        public EPieceColor PieceColor { get; }
        public bool isEmpty { get; }
        public ECellType CellType { get; }

        public CellId Identifier
        {
            get
            {
                return (CellId.Create(_rowIndex, _colIndex));
            }
        }

        public void SetPiece(EPieceColor pieceColor)
        {
            throw new NotImplementedException();
        }

        public bool isCellCurrentlySelected { get; set; }
        public bool isValidTarget { get; set; }
        public event EventHandler<CellId> SelectedCell = delegate{};
        public RelayCommand CellSelectedCommand { get; }
    }
}