using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class PatrolCommand : IPatrolCommand
    {
        public PatrolCommand(Vector3 target, Vector3 groundClick)
        {
            From = target;
            To = groundClick;
        } 
        
        public Vector3 From { get; }
        public Vector3 To { get; }
    }
}