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
        private TransformValue _transformValue = default;
        
        [Inject]
        private void Init(TransformValue transformClicks) => _transformValue = transformClicks;

        private void OnNewValue(Transform enemyClick)
        {
             _attackCallback?.Invoke(_context.Inject(new AttackCommand(enemyClick)));
             _transformValue.onNewValue -= OnNewValue;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {
            _attackCallback = creationCallback;
            _transformValue.onNewValue += OnNewValue;
        } 

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _transformValue.onNewValue -= OnNewValue;
            _attackCallback = null;
        }
    }
}