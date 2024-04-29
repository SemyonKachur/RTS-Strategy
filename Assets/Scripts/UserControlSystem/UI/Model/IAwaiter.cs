using System.Runtime.CompilerServices;

namespace UserControlSystem
{
    public interface IAwaiter<TAwaited> : INotifyCompletion
    {
        bool IsCompleted { get; }
        TAwaited GetResult();
    }
}