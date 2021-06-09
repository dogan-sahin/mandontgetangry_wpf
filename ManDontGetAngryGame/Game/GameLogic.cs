using System;
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
                targetCell = _gameBoard.GetPlayingCell((sourceCell.Position + diceValue) % _gameBoard.TotalPlayPositions);

                if (_gameRules.IsMovedCellOccupiedByOpponent(sourceCell.Identifier, targetCell.Identifier, _gameBoard))
                {
                    _gameBoard.MovePiece(targetCell.Identifier, _gameBoard.GetStartCell(EPieceColor.Green));
                    ActiveGreenCell = _gameBoard.GetStartCell(EPieceColor.Green);
                }

                if (_gameRules.IsMovedCellLastPlayingCell(sourceCell.Identifier, diceValue, _gameBoard))
                {
                    if (_gameBoard.GetPieceFromHome(ECellColor.Blue) != null)
                    {
                        targetCell = _gameBoard.GetCell(_gameBoard.GetFreeEndCell(EPieceColor.Blue));
                        _gameBoard.SetStartPiece(EPieceColor.Blue);
                        ActiveBlueCell = _gameBoard.GetStartCell(EPieceColor.Blue);
                        _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
                        nextTurn();
                        return;
                    }
                    else
                    {
                        targetCell = _gameBoard.GetCell(_gameBoard.GetFreeEndCell(EPieceColor.Blue));
                        _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
                        GameFinished(this, new GameFinishedEventArgs(ActivePlayer));
                    }

                }
                ActiveBlueCell = targetCell.Identifier;
                _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
                nextTurn();
            }
            else
            {
                sourceCell = _gameBoard.GetCell(ActiveGreenCell);
                targetCell = _gameBoard.GetPlayingCell((sourceCell.Position + diceValue) % _gameBoard.TotalPlayPositions);

                if (_gameRules.IsMovedCellOccupiedByOpponent(sourceCell.Identifier, targetCell.Identifier, _gameBoard))
                {
                    _gameBoard.MovePiece(targetCell.Identifier, _gameBoard.GetStartCell(EPieceColor.Blue));
                    ActiveBlueCell = _gameBoard.GetStartCell(EPieceColor.Blue);
                }
                if (_gameRules.IsMovedCellLastPlayingCell(sourceCell.Identifier, diceValue, _gameBoard))
                {
                    if (_gameBoard.GetPieceFromHome(ECellColor.Green) != null)
                    {
                        targetCell = _gameBoard.GetCell(_gameBoard.GetFreeEndCell(EPieceColor.Green));
                        _gameBoard.SetStartPiece(EPieceColor.Green);
                        ActiveGreenCell = _gameBoard.GetStartCell(EPieceColor.Green);
                        _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
                        nextTurn();
                        return;
                    }
                    else
                    {
                        targetCell = _gameBoard.GetCell(_gameBoard.GetFreeEndCell(EPieceColor.Green));
                        _gameBoard.MovePiece(sourceCell.Identifier, targetCell.Identifier);
                        GameFinished(this, new GameFinishedEventArgs(ActivePlayer));
                        return;
                    }
                }
                ActiveGreenCell = targetCell.Identifier;
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
