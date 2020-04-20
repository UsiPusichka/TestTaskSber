using Sbt.Test.Refactoring.Abstractions;

namespace Sbt.Test.Refactoring.Interfaces
{
    public interface ICommandReceiver : ISelectedUnits<Unit>
    {
        /// <summary>
        /// Отдать комманду выделенным юнитам
        /// </summary>
        void Move(string command);
    }
}
