using System;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class AttackCommandCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        [Inject] private AssetsContext _context;
        private Action<IAttackCommand> _attackCallback;
        private Vector3Value _vector3Value = default;
        
        [Inject]
        private void Init(Vector3Value transformClicks) => _vector3Value = transformClicks;

        private void OnNewValue(Vector3 enemyClick)
        {
             _attackCallback?.Invoke(_context.Inject(new AttackCommand(enemyClick)));
             _vector3Value.onNewValue -= OnNewValue;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _attackCallback = creationCallback;
            _vector3Value.onNewValue += OnNewValue;
        } 

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _vector3Value.onNewValue -= OnNewValue;
            _attackCallback = null;
        }
    }
}