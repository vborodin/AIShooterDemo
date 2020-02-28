using UnityEngine;

namespace AIShooterDemo
{
    public class FallbackPositionNode : INode
    {
        public string Name => "RandomDestinationBehind";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            Vector3 random = new Vector3(
                Random.Range(-3f, 3f),
                Random.Range(-3f, 3f),
                Random.Range(-3f, 3f)
            );
            agent.SetDestination(agent.Position + agent.LookVector * -5f + random);
            return NodeState.Success;
        }
    }
}