using Sbt.Test.Refactoring.Abstractions;
using System.Collections.Generic;

namespace Sbt.Test.Refactoring.Interfaces
{
    public interface ISelectedUnits<TUnit> where TUnit : Unit
    {
        List<TUnit> SelectedUnits { get; }

        /// <summary>
        /// Эмуляция выделения юнитов рамкой
        /// </summary>
        /// <param name="units"></param>
        void SelectUnits(IEnumerable<TUnit> units);
    }
}
