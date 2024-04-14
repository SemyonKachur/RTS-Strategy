using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class PatrolCommand : IPatrolCommand
    {
        public Vector3 Target { get; protected set; }
        
        public PatrolCommand(Vector3 target) => Target = target;
    }
}