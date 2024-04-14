using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class AttackCommand : IAttackCommand
    {
        public Transform Target { get; set; }

        public AttackCommand(Transform target) => Target = target;
    }
}