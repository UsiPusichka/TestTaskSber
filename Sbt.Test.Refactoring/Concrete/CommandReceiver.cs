using Sbt.Test.Refactoring.Abstractions;
using Sbt.Test.Refactoring.Exceptions;
using Sbt.Test.Refactoring.Interfaces;
using System;
using System.Linq;

namespace Sbt.Test.Refactoring.Concrete
{
    public class CommandReceiver : ACommandReceiver
    {
        /// <inheritdoc/>
        /// <param name="command">По умолчанию поддерживается "F", "T"</param>
        public override void Move(string command)
        {
            if (string.IsNullOrEmpty(command))
                throw new ArgumentNullException(nameof(command));

            if (!SelectedUnits.Any())
                return;

            Action<Unit> action;

            if (command == "F")
            {
                action = unit =>
                {
                    if (unit is IMoveForwards)
                        ((IMoveForwards)unit).MoveForwards();
                };
            }
            else if (command == "T")
            {
                action = unit =>
                {
                    if (unit is ITurnClockwise)
                        ((ITurnClockwise)unit).TurnClockwise();
                };
            }
            else
            {
                throw new UnsupportCommandException();
            }

            SelectedUnits.ForEach(action);
        }
    }
}
