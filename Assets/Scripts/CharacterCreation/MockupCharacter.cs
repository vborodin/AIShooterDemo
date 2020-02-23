using UnityEngine;
using UnityEngine.AI;

namespace AIShooterDemo
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MockupCharacter : CharacterBase<MockupCharacterData>
    {
        protected override void Init(MockupCharacterData data)
        {
            var agent = GetComponent<NavMeshAgent>();
            agent.enabled = true;
            agent.destination = data.destination;
        }
    }
}