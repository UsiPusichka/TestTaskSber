using Sbt.Test.Refactoring.Concrete;
using Sbt.Test.Refactoring.Interfaces;

namespace Sbt.Test.Refactoring.Tests.Base
{
    public abstract class BaseTest
    {
        protected IField Field;
        protected ICommandReceiver CommandReceiver;

        public BaseTest()
        {
            Field = Concrete.Field.GetInstance();
            CommandReceiver = new CommandReceiver();
        }
    }
}
