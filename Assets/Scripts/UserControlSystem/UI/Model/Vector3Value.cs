using UnityEngine;

namespace UserControlSystem
{
    using UserControlSystem.UI.Model;

    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "Strategy Game/" + nameof(Vector3Value), order = 0)]
    public sealed class Vector3Value : StatelessScriptableObjectValueBase<Vector3>
    { 

    }
}