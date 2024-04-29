using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommand : IAttackCommand
    {
        public Vector3 Target { get; set; }

        public AttackCommand(Vector3 target) => Target = target;
    }
}