using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManDontGetAngryGame.Enums;

namespace ManDontGetAngryGame.Model
{
    public class CellId
    {
        private int _position;
        public int Position
        {
            get { return _position; }
        }

        private ECellColor _color;
        public ECellColor Color
        {
            get { return _color; }
        }


        private ECellType _type;
        public ECellType Type
        {
            get { return _type; }
        }


        private CellId(int position, ECellColor color, ECellType type)
        {
            _position = position;
            _color = color;
            _type = type;
        }
        public static CellId Create(int position, ECellColor color, ECellType type)
        {
            return new CellId(position, color, type);
        }

        public override bool Equals(object other)
        {
            var otherCasted = other as CellId;
            if (otherCasted == null)
            {
                return false;
            }
            return otherCasted.Position == this.Position && otherCasted.Color == this.Color && otherCasted.Type == this.Type;
        }

        public override int GetHashCode()
        {
            return ("" + Position + Color + Type).GetHashCode(); // Create a string and re-use the HashCode
        }
    }
}
