using System.Linq;
using Abstractions;
using UnityEngine;
using UnityEngine.EventSystems;
using UserControlSystem;

public sealed class MouseInteractionPresenter : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SelectableValue _selectedObject;
    [SerializeField] private EventSystem _eventSystem;

    [SerializeField] private TransformValue _selectableObject;
    [SerializeField] private Vector3Value _groundClicksRMB;
    [SerializeField] private Transform _groundTransform;
    
    private Plane _groundPlane;
    private RaycastHit[] _hits = default;
    private ISelectable _selectable = default;
    
    private void Start() => _groundPlane = new Plane(_groundTransform.up, 0);

    private void Update()
    {
        if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
        {
            return;
        }
        if (_eventSystem.IsPointerOverGameObject())
        {
            return;
        }
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonUp(0))
        {
            _hits = Physics.RaycastAll(ray);
            if (_hits.Length == 0)
            {
                return;
            }
            _selectable = _hits
                .Select(hit => hit.collider.GetComponentInParent<ISelectable>())
                .FirstOrDefault(c => c != null);
            _selectedObject.SetValue(_selectable);
        }
        else
        {
            if (_groundPlane.Raycast(ray, out var enter))
            {
                _groundClicksRMB.SetValue(ray.origin + ray.direction * enter);
            }
            
            _hits = Physics.RaycastAll(ray);
            if (_hits.Length == 0)
            {
                return;
            }
            
            foreach (RaycastHit raycastHit in _hits)
            {
                _selectable = raycastHit.collider.GetComponent<ISelectable>();
                if (_selectable != null)
                {
                    _selectableObject.SetValue(raycastHit.collider.transform);
                    break;
                }
            }
        }
    }
}