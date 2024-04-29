using Abstractions.Commands;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(AttackableValue), menuName = "Strategy Game/" + nameof(AttackableValue), order = 0)]
    public class AttackableValue : BaseSelectedObject<IAttackable>
    {
        
    }
}