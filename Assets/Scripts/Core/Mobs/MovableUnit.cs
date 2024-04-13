namespace Core.Mobs
{
    using UnityEngine;
    using Abstractions.Commands;
    using Abstractions.Commands.CommandsInterfaces;
    
    public class MovableUnit : CommandExecutorBase<IMoveCommand>
    {
        public override void ExecuteSpecificCommand(IMoveCommand command)
        {
            Debug.Log($"Move to {command.Position}");
        }
    }
}