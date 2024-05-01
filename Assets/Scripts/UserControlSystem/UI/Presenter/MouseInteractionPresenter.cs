namespace UserControlSystem.UI.Presenter
{
    using System;
    using System.Linq;
    using Abstractions;
    using Abstractions.Commands;
    using UniRx;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public sealed class MouseInteractionPresenter : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private EventSystem _eventSystem = default;
        [SerializeField]
        private SelectableValue _selectedObject;
        [SerializeField]
        private AttackableValue _attackablesRMB;
        [SerializeField]
        private Vector3Value _groundClicksRMB;
        [SerializeField]
        private Transform _groundTransform;

        private IObservable<long> _leftButtonStream = default;
        private IObservable<long> _rightButtonStream = default;
        private IObservable<long> _nonBlockedByUiFramesStream = default;

        private Ray _ray = default;
        private Plane _groundPlane;
        private RaycastHit[] _hits = default;
        private ISelectable _selectable = default;

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);
            _nonBlockedByUiFramesStream = Observable.EveryUpdate()
                .Where(_ => !_eventSystem.IsPointerOverGameObject());
            
            _leftButtonStream = _nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(0));
            _leftButtonStream.Subscribe(SelectItem);

            _rightButtonStream = _nonBlockedByUiFramesStream.Where(_ => Input.GetMouseButtonDown(1));
            _rightButtonStream.Subscribe(ActionCommand);
        }

        private void SelectItem(long stream)
        {
            SendRaycast();
            if (IsHit(_hits, out ISelectable selectable))
            {
                _selectedObject.SetValue(selectable);
            }
        }

        private void ActionCommand(long stream)
        {
            SendRaycast();
            if (IsHit(_hits, out IAttackable attackable))
            {
                _attackablesRMB.SetValue(attackable);
            }
            else if (_groundPlane.Raycast(_ray, out float enter))
            {
                _groundClicksRMB.SetValue(_ray.origin + _ray.direction * enter);
            }
        }

        private void SendRaycast()
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            _hits = Physics.RaycastAll(_ray);
        }

        private bool IsHit<T>(RaycastHit[] hits, out T result) where T : class
        {
            result = default;
            if (hits.Length == 0)
            {
                return false;
            }

            result = hits
                .Select(hit => hit.collider.GetComponentInParent<T>())
                .Where(c => c != null)
                .FirstOrDefault();
            return result != default;
        }
    }
}