namespace UserControlSystem.UI.Presenter
{
    using System;
    using UniRx;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Презентер меню паузы.
    /// </summary>
    public class PausePanelPresenter : MonoBehaviour
    {
        [SerializeField]
        private Button _backButton = default;
        [SerializeField]
        private Button _quitButton = default;
        [SerializeField]
        protected GameObject _pausePanel = default;
        
        private void OnEnable()
        {
            _backButton.OnClickAsObservable().Subscribe(DisablePausePanel);
            _quitButton.OnClickAsObservable().Subscribe(Quit);
        }

        private void Quit(Unit unit)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit();
            
        } 
        private void DisablePausePanel(Unit unit) => _pausePanel.SetActive(false);
    }
}