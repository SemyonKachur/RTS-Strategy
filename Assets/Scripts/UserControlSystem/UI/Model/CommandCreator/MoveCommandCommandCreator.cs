using System;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class MoveCommandCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IMoveCommand> _creationCallback;
        private Vector3Value _vector3Value = default;

        [Inject]
        private void Init(Vector3Value groundClicks) => _vector3Value = groundClicks;

        private void OnNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new MoveCommand(groundClick)));
            _vector3Value.onNewValue -= OnNewValue;
        }

        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
        {
            _creationCallback = creationCallback;
            _vector3Value.onNewValue += OnNewValue;
        }
        
        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _vector3Value.onNewValue -= OnNewValue;
            _creationCallback = null;
        }
    }
}