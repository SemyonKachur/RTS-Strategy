using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.Model.CommandCreator;
using Zenject;

namespace UserControlSystem
{
    public class PatrolCommandCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;

        protected override IPatrolCommand CreateCommand(Vector3 argument) =>
            new PatrolCommand(_selectable.CurrentValue.PivotPoint.position, argument);
    }
}