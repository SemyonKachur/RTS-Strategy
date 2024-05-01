namespace Core.Time
{
    using UniRx;
    using System;
    using Abstractions;
    using Zenject;
    
    /// <summary>
    /// Дата игрового времени.
    /// </summary>
    public class TimeModel : ITimeModel, ITickable
    {
        public IObservable<int> GameTime => _gameTime.Select(time => (int) time);
        private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();

        public void Tick()
        {
            _gameTime.Value += UnityEngine.Time.deltaTime;
        }
    }
}