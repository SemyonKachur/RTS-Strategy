using Abstractions.Commands;
using UnityEngine;

namespace UserControlSystem
{
    using UserControlSystem.UI.Model;

    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue : StatelessScriptableObjectValueBase<IAttackable>
    {
        
    }
}