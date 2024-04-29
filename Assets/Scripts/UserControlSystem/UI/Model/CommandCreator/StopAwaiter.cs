namespace UserControlSystem
{
    using System;
    
    public class StopAwaiter : IAwaiter<AsyncExtensions.Void>
    {
        private readonly UnitMovementStop _unitMovementStop;
        private Action _continuation;
        private bool _isCompleted;

        public StopAwaiter(UnitMovementStop unitMovementStop)
        {
            _unitMovementStop = unitMovementStop;
            _unitMovementStop.OnStop += onStop;
        }

        private void onStop()
        {
            _unitMovementStop.OnStop -= onStop;
            _isCompleted = true;
            _continuation?.Invoke();
        }

        public void OnCompleted(Action continuation)
        {
            if (_isCompleted)
            {
                continuation?.Invoke();
            }
            else
            {
                _continuation = continuation;
            }
        }

        public bool IsCompleted => _isCompleted;
        public AsyncExtensions.Void GetResult() => new AsyncExtensions.Void();
    }
}