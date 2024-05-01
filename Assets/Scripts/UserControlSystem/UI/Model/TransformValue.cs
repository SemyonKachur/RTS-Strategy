using UnityEngine;

namespace UserControlSystem
{
    using UserControlSystem.UI.Model;

    [CreateAssetMenu(fileName = nameof(TransformValue), menuName = "Strategy Game/" + nameof(TransformValue), order = 0)]
    public class TransformValue : StatelessScriptableObjectValueBase<Transform>
    {
    }
}