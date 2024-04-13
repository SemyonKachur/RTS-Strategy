namespace Abstractions.Commands.CommandsInterfaces
{
    using UnityEngine;  

    public interface IAttackCommand : ICommand
    {
        Transform Target { get; set; }
    }
}