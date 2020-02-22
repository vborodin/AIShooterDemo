using UnityEngine;
using UnityEngine.AI;

namespace AIShooterDemo
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveTo : MonoBehaviour
    {
        public void Init(Vector3 startPosition, Vector3 endPosition)
        {
            var agent = GetComponent<NavMeshAgent>();
            agent.enabled = true;
            agent.transform.position = startPosition;
            agent.destination = endPosition;
        }
    }
}