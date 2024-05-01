namespace Core.Mobs
{
    using System.Threading;
    using Abstractions.Commands;
    using Abstractions.Commands.CommandsInterfaces;
    
    public class StoppableUnit : CommandExecutorBase<IStopCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; } = new CancellationTokenSource();
        public override void ExecuteSpecificCommand(IStopCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }
}