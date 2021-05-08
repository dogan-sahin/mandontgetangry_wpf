using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool IsMovedCellOccupiedByTeam(CellId source, CellId target, GameBoard board)
        {
            var sourceCell = board.GetCell(source);
            var targetCell = board.GetCell(target);

            if (sourceCell.PieceColor == targetCell.PieceColor)
            {
                return true;
            }

            return false;
        }

        public bool areAllEndCellsOccupied(ECellColor color, GameBoard board)
        {
            var endcells = board.Cells.Where(cell =>
                cell.Key.Color.Equals(color) && cell.Key.Type.Equals(ECellType.EndCell));

            foreach (var cell in endcells)
            {
                if (cell.Value.PieceColor == EPieceColor.None)
                {
                    return false;
                }

                return true;
            }

            return true;
        }




    }
}
