using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Enums;
using ManDontGetAngryGame.Model;

namespace ManDontGetAngryGame.ViewModels
{
    public interface ICellStatusViewModel : INotifyPropertyChanged
    {
        ECellColor CellColor { get; set; }
        EPieceColor PieceColor { get; set; }
        void SetPiece(EPieceColor piece);
        CellId Identifier { get; }
        bool IsEmpty { get; }

    }
}
