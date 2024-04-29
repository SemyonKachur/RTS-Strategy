namespace Core.Mobs
{
    using UserControlSystem;
    using UnityEngine.AI;
    using UnityEngine;
    using Abstractions.Commands;
    using Abstractions.Commands.CommandsInterfaces;
    
    public class MovableUnit : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private NavMeshAgent _agent = default;
        [SerializeField] private Animator _animator = default;

        private const string IDLE = "Idle";
        private const string MOVE = "Move";

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            _agent.SetDestination(command.Target);
            _animator.SetTrigger(MOVE);
            await _stop;
            _animator.SetTrigger(IDLE);
        }
    }
}