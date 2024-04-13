namespace Abstractions.Commands.CommandsInterfaces
{
    using UnityEngine;
    public interface IMoveCommand : ICommand
    {
        Vector3 Position { get; set; }
    }
}