using Abstractions.Commands;

namespace Core.Mobs
{
    using Abstractions;
    using UnityEngine;

    public class SelectableUnit : MonoBehaviour, ISelectable, IAttackable
    {
        public Transform PivotPoint => transform;
        
        public float Health => health;
        [SerializeField, Min(0)] protected float health = 100;

        public float MaxHealth => maxHealth;
        [SerializeField,Min(1)] protected float maxHealth = 100;

        public Sprite Icon => icon;
        [SerializeField] protected Sprite icon = default;
    }
}