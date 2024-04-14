    using Abstractions;
    using UnityEngine;
    using UserControlSystem;

    [RequireComponent(typeof(ISelectable))]
    public class SelectableOutlinePresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue = default;
        [SerializeField] private Outline _outline = default;

        private ISelectable _selectable = default;

        private void Awake() => _selectable = GetComponent<ISelectable>();

        private void OnEnable()
        {
            SelectObject(_selectedValue.CurrentValue);
            _selectedValue.onNewValue += SelectObject;
        } 

        private void SelectObject(ISelectable selectedObject) => 
            _outline.enabled = selectedObject != null && _selectable == selectedObject;

        private void OnDisable() => _selectedValue.onNewValue -= SelectObject;
    }
