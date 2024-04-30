namespace UserControlSystem.UI.Model
{
    using System;
    
    public class AwaiterBase<T> : IAwaiter<T>
    {
        private Action _onContinue = delegate { };
        
        public bool IsCompleted => isCompleted;
        protected bool isCompleted = default;

        protected T result = default;
        
        public void OnCompleted(Action continuation)
        {
            if (IsCompleted)
            {
                _onContinue();
            }
            else
            {
                _onContinue = continuation;
            }
        }

        public T GetResult() => result;

        protected virtual void OnWaitFinish(T commandResult)
        {
            result = commandResult;
            isCompleted = true;
            _onContinue();
        }
    }
}