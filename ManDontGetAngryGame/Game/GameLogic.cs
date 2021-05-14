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

        private CellId _activeBlueCell;
        private CellId _activeGreenCell;

        private int totalPlayPositions = 24;

        public CellId ActiveBlueCell
        {
            get { return _activeBlueCell; }
            set
            {
                if (_activeBlueCell != value)
                {
                    _activeBlueCell = value;
                }
            }
        }

        public CellId ActiveGreenCell
        {
            get { return _activeGreenCell; }
            set
            {
                if (_activeGreenCell != value)
                {
                    _activeGreenCell = value;
                }
            }
        }


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
            ActiveBlueCell = _gameBoard.GetStartCell(EPieceColor.Blue);
            ActiveGreenCell = _gameBoard.GetStartCell(EPieceColor.Green);
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

        public void MovePiece (int diceValue, EActivePlayer activePlayer)
        {
            CellModel sourceCell;
            CellModel targetCell;
            if (activePlayer == EActivePlayer.Blue)
            {
                sourceCell = _gameBoard.GetCell(ActiveBlueCell);
                targetCell = _gameBoard.GetPlayingCell((sourceCell.Position + diceValue) % totalPlayPositions);
                ActiveBlueCell = targetCell.Identifier;

                if (_gameRules.IsMovedCellOccupiedByOpponent(sourceCell.Identifier, targetCell.Identifier, _gameBoard))
                {
                    _gameBoard.SetStartPiece(EPieceColor.Green);
                    return;
                }
                _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
                nextTurn();
            }
            else
            {
                sourceCell = _gameBoard.GetCell(ActiveGreenCell);
                targetCell = _gameBoard.GetPlayingCell((sourceCell.Position + diceValue) % totalPlayPositions);
                ActiveGreenCell = targetCell.Identifier;

                if (_gameRules.IsMovedCellOccupiedByOpponent(sourceCell.Identifier, targetCell.Identifier, _gameBoard))
                {
                    _gameBoard.SetStartPiece(EPieceColor.Blue);
                    return;
                }
                _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
                nextTurn();
            }

          

        }

        public EActivePlayer ActivePlayer
        {
            get { return _activePlayer; }
        }


    }
}
