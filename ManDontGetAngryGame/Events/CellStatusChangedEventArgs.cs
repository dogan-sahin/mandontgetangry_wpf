using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Enums;
using ManDontGetAngryGame.Model;

namespace ManDontGetAngryGame.Events
{
    public class CellStatusChangedEventArgs : EventArgs
    {
        public CellId Identifier { get; }
        public EPieceColor OldPiece { get; }
        public EPieceColor NewPiece { get; }

        public CellStatusChangedEventArgs(CellId identifier, EPieceColor oldPiece, EPieceColor newPiece)
        {
            Identifier = identifier;
            OldPiece = oldPiece;
            NewPiece = newPiece;
        }
    }
}
