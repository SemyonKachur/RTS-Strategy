namespace UserControlSystem.UI.Presenter
{
    using System;
    using Abstractions;
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;
    using Zenject;

    /// <summary>
    /// Презентер игрового таймера
    /// </summary>
    public class GameTimePresenter : MonoBehaviour
    {
        private const string TIME_FORMAT = "{0:D2}:{1:D2}";
        
        [SerializeField]
        private Text _text = default;
       
        private ITimeModel _timeModel = default;
        private TimeSpan _gameTime = default;

        [Inject]
        private void Construct(ITimeModel timeModel)
        {
            _timeModel = timeModel;
            _timeModel.GameTime.Subscribe(UpdateTimer);
        }

        private void UpdateTimer(int seconds)
        {
            _gameTime = TimeSpan.FromSeconds(seconds);
            _text.text = string.Format(TIME_FORMAT,
                _gameTime.Minutes,
                _gameTime.Seconds);
        }
    }
}