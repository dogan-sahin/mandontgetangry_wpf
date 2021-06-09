using ManDontGetAngryGame.Enums;
using ManDontGetAngryGame.Model;

namespace ManDontGetAngryGame.Game
{
    public class GameRules
    {
        public bool IsMovedCellOccupiedByOpponent(CellId source, CellId target, GameBoard board)
        {
            var sourceCell = board.GetCell(source);
            var targetCell = board.GetCell(target);

            if (sourceCell.PieceColor != targetCell.PieceColor)
            {
                if (targetCell.PieceColor == EPieceColor.None)
                {
                    return false;
                }
                return true;
            }

            return false;
        }


        public bool IsMovedCellLastPlayingCell(CellId source, int diceValue, GameBoard board)
        {
            var sourceCell = board.GetCell(source);

            for (int i = sourceCell.Position; i <= sourceCell.Position + diceValue % board.TotalPlayPositions; i++)
            {
                if (sourceCell.PieceColor == EPieceColor.Blue && i == board.GetLastPlayingCell(EPieceColor.Blue).Position)
                {
                    return true;
                }

                if (sourceCell.PieceColor == EPieceColor.Green && i == board.GetLastPlayingCell(EPieceColor.Green).Position)
                {
                    return true;
                }

            }
            return false;
        }


    }
}
