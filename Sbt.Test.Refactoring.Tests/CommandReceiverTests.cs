using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Concrete.Units;
using Sbt.Test.Refactoring.Exceptions;
using Sbt.Test.Refactoring.Interfaces;
using Sbt.Test.Refactoring.Tests.Base;
using System;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class CommandReceiverTests : BaseTest
    {
        public CommandReceiverTests() : base() { }

        [TestMethod]
        public void TestShouldSupportCommand()
        {
            CommandReceiver.SelectUnits(new Unit[] { new Tractor(Field) });

            CommandReceiver.Move("F");
            CommandReceiver.Move("T");
        }

        [TestMethod]
        public void TestDontShouldSupportCommand()
        {
            CommandReceiver.SelectUnits(new Unit[] { new Tractor(Field) });

            try
            {
                CommandReceiver.Move("test");
                Assert.Fail("CommandReceiver should give out exception");
            }
            catch (UnsupportCommandException)
            {
            }
        }

        [TestMethod]
        public void TestSupportCommandMoveForvard()
        {
            CommandReceiver.SelectUnits(new Unit[] { new Tractor(Field), new Stone(Field), new Wind(Field) });
            CommandReceiver.Move("F");

            Assert.AreEqual(0, ((Tractor)CommandReceiver.SelectedUnits[0]).GetPositionX());
            Assert.AreEqual(1, ((Tractor)CommandReceiver.SelectedUnits[0]).GetPositionY());

            Assert.AreEqual(0, ((Stone)CommandReceiver.SelectedUnits[1]).GetPositionX());
            Assert.AreEqual(0, ((Stone)CommandReceiver.SelectedUnits[1]).GetPositionY());

            try
            {
                var wind = (IPosition)(Wind)CommandReceiver.SelectedUnits[2];
                Assert.Fail("Object \"wind\" shold not support IPosition");
            }
            catch (InvalidCastException)
            {
            }
        }

        [TestMethod]
        public void TestSupportCommandTurnClockwise()
        {
            CommandReceiver.SelectUnits(new Unit[] { new Tractor(Field), new Stone(Field), new Wind(Field) });
            CommandReceiver.Move("T");

            Assert.AreEqual(Enums.Orientation.East, ((Tractor)CommandReceiver.SelectedUnits[0]).Orientation);
            Assert.AreEqual(Enums.Orientation.East, ((Wind)CommandReceiver.SelectedUnits[2]).Orientation);

            Assert.AreEqual(0, ((Stone)CommandReceiver.SelectedUnits[1]).GetPositionX());
            Assert.AreEqual(0, ((Stone)CommandReceiver.SelectedUnits[1]).GetPositionY());

            try
            {
                var wind = (IOrientation)(Wind)CommandReceiver.SelectedUnits[1];
                Assert.Fail("Object \"stone\" shold not support IOrientation");
            }
            catch (InvalidCastException)
            {
            }
        }
    }
}
