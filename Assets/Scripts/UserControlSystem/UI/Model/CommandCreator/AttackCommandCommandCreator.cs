using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.Model.CommandCreator;

namespace UserControlSystem
{
    public class AttackCommandCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) =>
            new AttackCommand(argument);
    }
}