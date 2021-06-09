using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Enums;

namespace ManDontGetAngryGame.Model
{
    public static class CellPositions
    {
        public static Tuple<int, ECellColor, ECellType> key(int position, ECellColor color, ECellType type)
        {
            return new Tuple<int, ECellColor, ECellType>(position, color, type);
        }

        private static Dictionary<Tuple<int, ECellColor, ECellType>, Tuple<int, int>> _positions =
           new Dictionary<Tuple<int, ECellColor, ECellType>, Tuple<int, int>>();

        public static Dictionary<Tuple<int, ECellColor, ECellType>, Tuple<int, int>> Positions
        {
            get {
                return _positions;
            }
        }

        public static void SetupPositions(int rows, int cols)
        {

            int middle = rows / 2;

            //Home Positions
            _positions.Add(key(1, ECellColor.Blue, ECellType.HomeCell), new Tuple<int, int>(0, 0));
            _positions.Add(key(2, ECellColor.Blue, ECellType.HomeCell), new Tuple<int, int>(0, 1));
            _positions.Add(key(3, ECellColor.Blue, ECellType.HomeCell), new Tuple<int, int>(1, 0));
            _positions.Add(key(4, ECellColor.Blue, ECellType.HomeCell), new Tuple<int, int>(1, 1));

            _positions.Add(key(1, ECellColor.Green, ECellType.HomeCell), new Tuple<int, int>(rows - 2, cols - 2));
            _positions.Add(key(2, ECellColor.Green, ECellType.HomeCell), new Tuple<int, int>(rows - 2, cols - 1));
            _positions.Add(key(3, ECellColor.Green, ECellType.HomeCell), new Tuple<int, int>(rows - 1, cols - 2));
            _positions.Add(key(4, ECellColor.Green, ECellType.HomeCell), new Tuple<int, int>(rows - 1, cols - 1));

            //Start Positions
            _positions.Add(key(1, ECellColor.Blue, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 0));
            _positions.Add(key(13, ECellColor.Green, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, cols - 1));

            //End Positions
            _positions.Add(key(1, ECellColor.Blue, ECellType.EndCell), new Tuple<int, int>(middle, 1));
            _positions.Add(key(2, ECellColor.Blue, ECellType.EndCell), new Tuple<int, int>(middle, 2));
            _positions.Add(key(3, ECellColor.Blue, ECellType.EndCell), new Tuple<int, int>(middle, 3));
            _positions.Add(key(4, ECellColor.Blue, ECellType.EndCell), new Tuple<int, int>(middle, 4));

            _positions.Add(key(1, ECellColor.Green, ECellType.EndCell), new Tuple<int, int>(middle, 9));
            _positions.Add(key(2, ECellColor.Green, ECellType.EndCell), new Tuple<int, int>(middle, 8));
            _positions.Add(key(3, ECellColor.Green, ECellType.EndCell), new Tuple<int, int>(middle, 7));
            _positions.Add(key(4, ECellColor.Green, ECellType.EndCell), new Tuple<int, int>(middle, 6));

            //Play Positions
            _positions.Add(key(2, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 1));
            _positions.Add(key(3, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 2));
            _positions.Add(key(4, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 3));
            _positions.Add(key(5, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 4));
            _positions.Add(key(6, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 5));
            _positions.Add(key(7, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 6));
            _positions.Add(key(8, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 7));
            _positions.Add(key(9, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 8));
            _positions.Add(key(10, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 9));
            _positions.Add(key(11, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle - 1, 10));

            _positions.Add(key(12, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle, cols - 1));

            _positions.Add(key(14, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 9));
            _positions.Add(key(15, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 8));
            _positions.Add(key(16, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 7));
            _positions.Add(key(17, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 6));
            _positions.Add(key(18, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 5));
            _positions.Add(key(19, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 4));
            _positions.Add(key(20, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 3));
            _positions.Add(key(21, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 2));
            _positions.Add(key(22, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 1));
            _positions.Add(key(23, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle + 1, 0));
            _positions.Add(key(24, ECellColor.White, ECellType.PlayingCell), new Tuple<int, int>(middle, 0));
        }



    }
}
