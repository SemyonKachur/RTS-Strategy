namespace UserControlSystem
{
    using UnityEngine;
    using System;
    using UnityEngine.AI;
    
    public class UnitMovementStop : MonoBehaviour, IAwaitable<AsyncExtensions.Void>
    {
        public event Action OnStop = delegate { };
        
        [SerializeField] private NavMeshAgent _agent;
        private void Update()
        {
            if (!_agent.pathPending)
            {
                if (_agent.remainingDistance <= _agent.stoppingDistance)
                {
                    if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                    {
                        OnStop?.Invoke();
                    }
                }
            }
        }
        public IAwaiter<AsyncExtensions.Void> GetAwaiter() => new StopAwaiter(this);
    }
}