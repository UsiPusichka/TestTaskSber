using Sbt.Test.Refactoring.Interfaces;

namespace Sbt.Test.Refactoring.Abstractions
{
    public abstract class Unit
    {
        protected IField Field { get; }
        public Unit(IField field) => Field = field;
    }
}
