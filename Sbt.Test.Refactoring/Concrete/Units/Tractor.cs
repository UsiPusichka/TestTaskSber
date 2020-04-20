using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Enums;
using Sbt.Test.Refactoring.Exceptions;
using Sbt.Test.Refactoring.Interfaces;

namespace Sbt.Test.Refactoring.Concrete.Units
{
    public class Tractor : Unit, IPosition, IOrientation, IMoveForwards, ITurnClockwise
    {
        private int[] _position = new int[] { 0, 0 };

        public Tractor(IField field, Orientation orientation, int posX, int posY) : 
            this(field, posX, posY) => 
            Orientation = orientation;
        public Tractor(IField field, int posX, int posY) : this(field)
        {
            _position[0] = posX;
            _position[1] = posY;
        }
        public Tractor(IField field) : base(field) { }

        public Orientation Orientation { get; private set; } = Orientation.North;

        public int GetPositionX() => _position[0];
        public int GetPositionY() => _position[1];

        public void MoveForwards()
        {
            if (_position[0] + 1 > Field.X || _position[1] + 1 > Field.Y)
                throw new TractorInDitchException();

            switch (Orientation)
            {
                case Orientation.North:
                    _position[1]++; break;
                case Orientation.East:
                    _position[0]++; break;
                case Orientation.South:
                    _position[1]--; break;
                case Orientation.West:
                    _position[0]--; break;
            }
        }

        public void TurnClockwise()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    Orientation = Orientation.East; break;
                case Orientation.East:
                    Orientation = Orientation.South; break;
                case Orientation.South:
                    Orientation = Orientation.West; break;
                case Orientation.West:
                    Orientation = Orientation.North; break;
            }
        }
    }
}
