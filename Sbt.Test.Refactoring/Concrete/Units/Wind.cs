using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Enums;
using Sbt.Test.Refactoring.Interfaces;

namespace Sbt.Test.Refactoring.Concrete.Units
{
    public class Wind : Unit, IOrientation, ITurnClockwise
    {
        public Wind(IField field, Orientation orientation) : this(field) =>
            Orientation = orientation;
        public Wind(IField field) : base(field) { }

        public Orientation Orientation { get; private set; } = Orientation.North;

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
