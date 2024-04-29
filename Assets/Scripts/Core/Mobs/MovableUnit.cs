namespace Core.Mobs
{
    using UnityEngine.AI;
    using UnityEngine;
    using Abstractions.Commands;
    using Abstractions.Commands.CommandsInterfaces;
    
    public class MovableUnit : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] protected NavMeshAgent agent = default;

        public override async void ExecuteSpecificCommand(IMoveCommand command) => 
            agent.destination = command.Target;
    }
}