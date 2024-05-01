namespace UserControlSystem.UI.Model
{
    using System;
    using UniRx;

    public class StatelessScriptableObjectValueBase<T> : BaseSelectedObject<T>, IObservable<T>
    {
        private Subject<T> _innerDataSource = new Subject<T>();
        public override void SetValue(T value)
        {
            base.SetValue(value);
            _innerDataSource.OnNext(value);
        }
        public IDisposable Subscribe(IObserver<T> observer) =>
            _innerDataSource.Subscribe(observer);

    }
}