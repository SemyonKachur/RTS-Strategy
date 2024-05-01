namespace UserControlSystem.UI.Presenter
{
    using UniRx;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// Кнопка открытия меню
    /// </summary>
    public class PauseButtonPresenter : MonoBehaviour
    {
        [SerializeField]
        private Button _button = default;
        [SerializeField]
        private GameObject _menuPanel = default;

        private void OnEnable() => _button.OnClickAsObservable().Subscribe(OpenMenuPanel);

        private void OpenMenuPanel(Unit unit) => _menuPanel.SetActive(true);
    }
}