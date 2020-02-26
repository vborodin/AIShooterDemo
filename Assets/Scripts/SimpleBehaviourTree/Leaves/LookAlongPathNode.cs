using UnityEngine;

namespace AIShooterDemo
{
    public class LookAlongPathNode : INode
    {
        public string Name => "LookAlongPath";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            Vector3 target = agent.Destination;
            target = new Vector3(target.x, agent.Position.y, target.z);
            agent.LookAt(target);
            return NodeState.Success;
        }
    }
}