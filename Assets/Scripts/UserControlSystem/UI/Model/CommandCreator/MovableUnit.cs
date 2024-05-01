namespace Core.Mobs
{
    using System.Threading;
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
        [SerializeField] private StoppableUnit _stopCommand = default;

        private const string IDLE = "Idle";
        private const string MOVE = "Move";

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            _agent.SetDestination(command.Target);
            _animator.SetTrigger(Animator.StringToHash(MOVE));
            _stopCommand.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop.WithCancellation(_stopCommand.CancellationTokenSource.Token);
            }
            catch
            {
                _agent.isStopped = true;
                _agent.ResetPath();
            }
            _stopCommand.CancellationTokenSource = null;
            _animator.SetTrigger(Animator.StringToHash(IDLE));
        }
    }
}