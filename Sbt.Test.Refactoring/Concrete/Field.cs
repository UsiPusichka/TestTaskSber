using Sbt.Test.Refactoring.Interfaces;

namespace Sbt.Test.Refactoring.Concrete
{
    public class Field : IField
    {
        private static Field _instance;
        private static object _locker = new object();
        public int X { get; }
        public int Y { get; }

        private Field()
        {
            X = 5;
            Y = 5;
        }

        public static Field GetInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                        _instance = new Field();
                }
            }
            return _instance;
        }
    }
}
