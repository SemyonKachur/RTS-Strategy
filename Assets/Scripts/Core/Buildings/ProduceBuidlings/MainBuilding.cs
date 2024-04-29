using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public sealed class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
{
    public Transform PivotPoint => this.transform;
    public float Health { get; } = 1000;

    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    [SerializeField] private Transform _unitsParent;

    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    public override void ExecuteSpecificCommand(IProduceUnitCommand command) 
        => Instantiate(command.UnitPrefab, 
            new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), 
            Quaternion.identity, 
            _unitsParent);
}