namespace Abstractions.Commands.CommandsInterfaces
{
    using UnityEngine;  

    public interface IAttackCommand : ICommand
    {
        Vector3 Target { get; set; }
    }
}