using UnityEngine;
using UnityEngine.AI;

namespace AIShooterDemo
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class SingleCharacter : MonoBehaviour, ICharacter
    {
        public float Health { get; private set; }
        public Vector3 Position => transform.position;
        public Vector3 Destination => levelData.Destination;
        private ILevelData levelData;

        public void Init(CharacterData data, ILevelData levelData)
        {
            Health = data.Health;
            this.levelData = levelData;
        }

        public void Move(Vector3 destination)
        {
            var agent = GetComponent<NavMeshAgent>();
            agent.enabled = true;
            agent.destination = destination;
        }
    }
}