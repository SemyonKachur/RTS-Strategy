using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class MoveCommand: IMoveCommand
    {
        public Vector3 Position { get; set; }

        public void MoveTo(Vector3 pos) => Position = pos;
    }
}