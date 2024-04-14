using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(TransformValue), menuName = "Strategy Game/" + nameof(TransformValue), order = 0)]
    public class TransformValue : BaseSelectedObject<Transform>
    {
    }
}