namespace Core.Mobs
{
    using Abstractions.Commands;
    using Abstractions.Commands.CommandsInterfaces;
    using UnityEngine;
    
    public class AttackableUnit : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"Attack target {command.Target}");
        }
    }
}
