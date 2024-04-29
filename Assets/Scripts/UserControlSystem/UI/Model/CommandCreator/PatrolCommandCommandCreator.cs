using System;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class PatrolCommandCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        [Inject] private AssetsContext _context;
        [Inject] private SelectableValue _selectable;
        
        private Action<IPatrolCommand> _creationCallback;
        private Vector3Value vector3Value = default;

        [Inject]
        private void Init(Vector3Value groundClicks) => 
            vector3Value = groundClicks;

        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new
                PatrolCommand(_selectable.CurrentValue.PivotPoint.position, groundClick)));
            _creationCallback = null;
            vector3Value.onNewValue -= OnNewValue;
        }

        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            _creationCallback = creationCallback;
            vector3Value.onNewValue += OnNewValue;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            vector3Value.onNewValue -= OnNewValue;
            _creationCallback = null;
        }
    }
}