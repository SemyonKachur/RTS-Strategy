using System;
using UnityEngine;

namespace UserControlSystem
{
    public class BaseSelectedObject<T> : ScriptableObject
    {
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
    }
}