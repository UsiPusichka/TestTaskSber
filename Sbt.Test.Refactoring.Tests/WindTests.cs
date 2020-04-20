using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Concrete.Units;
using Sbt.Test.Refactoring.Enums;
using Sbt.Test.Refactoring.Tests.Base;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    class WindTests : BaseTest
    {
        public WindTests() : base() { }

        [TestMethod]
        public void TestShouldTurn()
        {
            var wind = new Wind(Field);
            CommandReceiver.SelectUnits(new Unit[] { wind });

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.East, wind.Orientation);

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.South, wind.Orientation);

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.West, wind.Orientation);

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.North, wind.Orientation);
        }
    }
}
