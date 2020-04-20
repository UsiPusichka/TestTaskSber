using Sbt.Test.Refactoring.Exceptions;
using Sbt.Test.Refactoring.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sbt.Test.Refactoring.Abstractions
{
    public abstract class ACommandReceiver : ICommandReceiver
    {
        public List<Unit> SelectedUnits { get; private set; } = new List<Unit>();

        /// <inheritdoc/>
        public abstract void Move(string command);

        public virtual void SelectUnits(IEnumerable<Unit> units)
        {
            if (units == null)
                throw new ArgumentNullException(nameof(units));
            if (!units.Any())
                throw new ArgumentException(nameof(units));

            SelectedUnits.Clear();
            SelectedUnits.AddRange(units);
        }
    }
}
