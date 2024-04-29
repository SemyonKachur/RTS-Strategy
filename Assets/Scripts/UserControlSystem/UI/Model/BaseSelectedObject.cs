using System;
using UnityEngine;

namespace UserControlSystem
{
    public abstract class BaseSelectedObject<T> : ScriptableObject, IAwaitable<T>
    {
        public class NewValueNotifier<TAwaited> : IAwaiter<TAwaited>
        {
            private readonly BaseSelectedObject<TAwaited> _scriptableObjectValueBase;
            private TAwaited _result;
            private Action _continuation;
            private bool _isCompleted;
            public NewValueNotifier(BaseSelectedObject<TAwaited> scriptableObjectValueBase)
            {
                _scriptableObjectValueBase = scriptableObjectValueBase;
                _scriptableObjectValueBase.onNewValue += OnNewValue;
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
            public TAwaited GetResult() => _result;
            
            private void OnNewValue(TAwaited obj)
            {
                _scriptableObjectValueBase.onNewValue -= OnNewValue;
                _result = obj;
                _isCompleted = true;
                _continuation?.Invoke();
            }
        }
        
        public Action<T> onNewValue = delegate { };

        public virtual T CurrentValue
        {
            get => currentValue;
            protected  set
            {
                currentValue = value;
                onNewValue(currentValue);
            }
        }

        protected T currentValue = default;

        public virtual void SetValue(T value) => 
            CurrentValue = value;

        public IAwaiter<T> GetAwaiter() => new NewValueNotifier<T>(this);
    }
}