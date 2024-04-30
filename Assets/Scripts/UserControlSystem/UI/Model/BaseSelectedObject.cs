using System;
using UnityEngine;
using UserControlSystem.UI.Model;

namespace UserControlSystem
{
    public abstract class BaseSelectedObject<T> : ScriptableObject, IAwaitable<T>
    {
        public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
        {
            private readonly BaseSelectedObject<TAwaited> _scriptableObjectValueBase;

            public NewValueNotifier(BaseSelectedObject<TAwaited> scriptableObjectValueBase)
            {
                _scriptableObjectValueBase = scriptableObjectValueBase;
                _scriptableObjectValueBase.onNewValue += OnNewValue;
            }

            private void OnNewValue(TAwaited obj)
            {
                _scriptableObjectValueBase.onNewValue -= OnNewValue;
                OnWaitFinish(obj);
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