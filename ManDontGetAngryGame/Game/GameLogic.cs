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
    public class GameLogic
    {
        private GameBoard _gameBoard;
        private GameRules _gameRules;
        private EActivePlayer _activePlayer = EActivePlayer.Blue;

        public event EventHandler<CellStatusChangedEventArgs> CellStatusChanged = delegate { };
        public event EventHandler<GameFinishedEventArgs> GameFinished = delegate { };

        public GameLogic(GameBoard gameBoard, GameRules gameRules)
        {
            _gameBoard = gameBoard;
            _gameRules = gameRules;
            _gameBoard.CellStatusChanged += _gameBoard_CellStatusChanged;
        }

        public void StartGame()
        {
            _gameBoard.InitializeBoard();
        }

        private void _gameBoard_CellStatusChanged(object sender, CellStatusChangedEventArgs e)
        {
            CellStatusChanged(this, e);
        }

        public int NumRows
        {
            get { return _gameBoard.NumRows; }
        }

        public int NumCols
        {
            get { return _gameBoard.NumCols; }
        }

        private void nextTurn()
        {
            if (_activePlayer == EActivePlayer.Blue)
            {
                _activePlayer = EActivePlayer.Green;
            }
            else
            {
                _activePlayer = EActivePlayer.Blue;
            }
        }

        public void MovePiece (CellId source, int diceValue)
        {
            var sourceCell = _gameBoard.GetCell(source);

            var targetCell = _gameBoard.GetPlayingCell(sourceCell.Position + diceValue);

            _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
        }

        public EActivePlayer ActivePlayer
        {
            get { return _activePlayer; }
        }


    }
}
