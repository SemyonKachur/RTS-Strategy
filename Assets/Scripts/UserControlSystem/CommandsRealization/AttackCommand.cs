using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommand : IAttackCommand
    {
        public IAttackable Target { get; set; }

        public AttackCommand(IAttackable target) => Target = target;
    }
}