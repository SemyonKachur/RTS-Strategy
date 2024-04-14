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
        
        [Inject]
        private void Init(TransformValue transformClicks)
        {
            transformClicks.onNewValue += OnNewValue;
            Debug.LogError("ATTACK INIT");
        }

        private void OnNewValue(Transform enemyClick) 
            => _attackCallback?.Invoke(_context.Inject(new AttackCommand(enemyClick)));

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback) 
            => _attackCallback = creationCallback;

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _attackCallback = null;
        }
    }
}