using System.Threading;
using System.Threading.Tasks;

namespace UserControlSystem
{
    using UnityEngine;

    public static class AsyncExtensions
    {
        public struct Void { }
        
        public static async Task<TResult> WithCancellation<TResult>(this Task<TResult> originalTask, CancellationToken cancellationToken)
        {
            var cancelTask = new TaskCompletionSource<Void>();
            using (cancellationToken.Register(token => ((TaskCompletionSource<Void>)token).TrySetResult(new Void()), cancelTask))
            {
                Task any = await Task.WhenAny(originalTask, cancelTask.Task);
                if (any == cancelTask.Task)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            return await originalTask;
        }
        
        public static Task<TResult> AsTask<TResult>(this IAwaitable<TResult> awaitable) => 
            Task.Run(async () => await awaitable);

        public static async Task<TResult> WithCancellation<TResult>(this IAwaitable<TResult> originalTask, CancellationToken cancellationToken) =>
            await WithCancellation(originalTask.AsTask(), cancellationToken);


    }
}