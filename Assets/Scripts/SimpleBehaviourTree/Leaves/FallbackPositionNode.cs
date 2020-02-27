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
            agent.SetDestination(agent.Position + agent.LookVector * -5f);
            return NodeState.Success;
        }
    }
}