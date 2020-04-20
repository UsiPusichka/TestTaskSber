using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Concrete.Units;
using Sbt.Test.Refactoring.Enums;
using Sbt.Test.Refactoring.Exceptions;
using Sbt.Test.Refactoring.Tests.Base;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class TractorTest : BaseTest
    {
        public TractorTest() : base() { }

        [TestMethod]
        public void TestShouldMoveForward()
        {
            var tractor = new Tractor(Field);
            CommandReceiver.SelectUnits(new Unit[] { tractor });

            CommandReceiver.Move("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(1, tractor.GetPositionY());
        }

        [TestMethod]
        public void TestShouldTurn()
        {
            var tractor = new Tractor(Field);
            CommandReceiver.SelectUnits(new Unit[] { tractor });

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.East, tractor.Orientation);

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.South, tractor.Orientation);

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.West, tractor.Orientation);

            CommandReceiver.Move("T");
            Assert.AreEqual(Orientation.North, tractor.Orientation);
        }

        [TestMethod]
        public void TestShouldTurnAndMoveInTheRightDirection()
        {
            var tractor = new Tractor(Field);
            CommandReceiver.SelectUnits(new Unit[] { tractor });

            CommandReceiver.Move("T");
            CommandReceiver.Move("F");
            Assert.AreEqual(1, tractor.GetPositionX());
            Assert.AreEqual(0, tractor.GetPositionY());

            CommandReceiver.Move("T");
            CommandReceiver.Move("F");
            Assert.AreEqual(1, tractor.GetPositionX());
            Assert.AreEqual(-1, tractor.GetPositionY());

            CommandReceiver.Move("T");
            CommandReceiver.Move("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(-1, tractor.GetPositionY());

            CommandReceiver.Move("T");
            CommandReceiver.Move("F");
            Assert.AreEqual(0, tractor.GetPositionX());
            Assert.AreEqual(0, tractor.GetPositionY());
        }

        [TestMethod]
        public void TestShouldThrowExceptionIfFallsOffPlateau()
        {
            var tractor = new Tractor(Field);
            CommandReceiver.SelectUnits(new Unit[] { tractor });

            CommandReceiver.Move("F");
            CommandReceiver.Move("F");
            CommandReceiver.Move("F");
            CommandReceiver.Move("F");
            CommandReceiver.Move("F");

            try
            {
                CommandReceiver.Move("F");
                Assert.Fail("Tractor was expected to fall off the plateau");
            }
            catch (TractorInDitchException)
            {
            }
        }
    }
}
