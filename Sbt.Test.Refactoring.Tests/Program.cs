namespace Sbt.Test.Refactoring.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandReceiverTest = new CommandReceiverTests();
            commandReceiverTest.TestShouldSupportCommand();
            commandReceiverTest.TestDontShouldSupportCommand();
            commandReceiverTest.TestSupportCommandMoveForvard();
            commandReceiverTest.TestSupportCommandTurnClockwise();

            var windTest = new WindTests();
            windTest.TestShouldTurn();

            var stone = new StoneTests();
            stone.TestDontShouldMoveForward();

            TractorTest test = new TractorTest();

            test.TestShouldMoveForward();
            test.TestShouldThrowExceptionIfFallsOffPlateau();
            test.TestShouldTurn();
            test.TestShouldTurnAndMoveInTheRightDirection();
        }
    }
}
