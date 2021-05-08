using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Enums;

namespace ManDontGetAngryGame.Events
{
    public class GameFinishedEventArgs : EventArgs
    {
        public EActivePlayer _winner;

        public EActivePlayer Winner
        {
            get { return _winner; }
        }

        public GameFinishedEventArgs(EActivePlayer winner)
        {
            _winner = winner;
        }
    }
}
