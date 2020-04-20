using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Interfaces;

namespace Sbt.Test.Refactoring.Concrete.Units
{
    public class Stone : Unit, IPosition
    {
        private int[] _position = new int[] { 0, 0 };

        public Stone(IField field, int posX, int posY) : this(field)
        {
            _position[0] = posX;
            _position[1] = posY;
        }
        public Stone(IField field) : base(field) { }

        public int GetPositionX() => _position[0];
        public int GetPositionY() => _position[1];
    }
}
