using Abstractions;
using UnityEngine;

namespace Core
{
    public class MainUnit : MonoBehaviour, ISelectable
    {
        public Transform PivotPoint => this.transform;
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;

        [SerializeField] private float _maxHealth = 100;
        [SerializeField] private Sprite _icon;
        [SerializeField]
        private float _health = 100;
    }
}