using System;
using System.ComponentModel;
using ManDontGetAngryGame.Enums;
using ManDontGetAngryGame.Model;

namespace ManDontGetAngryGame.ViewModels
{
    interface ICellStatusViewModel : INotifyPropertyChanged
    {
        EPieceColor PieceColor { get; }

        bool isEmpty { get; }

        ECellType CellType { get; }

        CellId Identifier { get; }

        void SetPiece(EPieceColor pieceColor);

        bool isCellCurrentlySelected { get; set; }

        bool isValidTarget { get; set; }

        event EventHandler<CellId> SelectedCell;

        RelayCommand CellSelectedCommand { get; }

    }
}