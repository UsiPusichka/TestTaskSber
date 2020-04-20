using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Concrete.Units;
using Sbt.Test.Refactoring.Tests.Base;

namespace Sbt.Test.Refactoring.Tests
{
    [TestClass]
    public class StoneTests : BaseTest
    {
        public StoneTests() : base() { }

        [TestMethod]
        public void TestDontShouldMoveForward()
        {
            var stone = new Stone(Field);
            CommandReceiver.SelectUnits(new Unit[] { stone });

            CommandReceiver.Move("F");
            Assert.AreEqual(0, stone.GetPositionX());
            Assert.AreEqual(0, stone.GetPositionY());
        }
    }
}
