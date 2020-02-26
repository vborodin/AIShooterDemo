using UnityEngine;

namespace AIShooterDemo
{
    public class RandomDestinationNode : INode
    {
        public string Name => "RandomDestination";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            float x = Random.Range(-10f, 10f);
            float z = Random.Range(-10f, 10f);
            agent.SetDestination(agent.Position + new Vector3(x, agent.Position.y, z));
            return NodeState.Success;
        }
    }
}