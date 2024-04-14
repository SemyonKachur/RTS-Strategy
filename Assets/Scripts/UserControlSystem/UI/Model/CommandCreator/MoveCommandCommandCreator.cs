using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Zenject;

namespace UserControlSystem
{
    public class MoveCommandCommandCreator : CommandCreatorBase<IMoveCommand>
    {
        [Inject] private Vector3Value _vector3Value = default;
        
        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback) 
            => creationCallback?.Invoke(new MoveCommand(_vector3Value.CurrentValue));
    }
}