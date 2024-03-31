using Abstractions;
using UnityEngine;

public class EnviromentItem : MonoBehaviour, ISelectable
{
    public float Health => _health;
    [SerializeField] private float _health = 100;
    public float MaxHealth => _maxHealth;
    [SerializeField] private float _maxHealth = 100;
    public Sprite Icon => _icon;
    [SerializeField] private Sprite _icon = default;
}
