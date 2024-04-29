namespace Abstractions.Commands.CommandsInterfaces
{
    using UnityEngine;  

    public interface IAttackCommand : ICommand
    {
        IAttackable Target { get; set; }
    }
}