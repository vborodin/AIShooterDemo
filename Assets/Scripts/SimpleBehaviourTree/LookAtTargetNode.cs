using UnityEngine;

namespace AIShooterDemo
{
    public class LookAtTargetNode : INode
    {
        public string Name => "LookAtTarget";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (agent.Target == null)
            {
                return NodeState.Failure;
            }
            agent.LookAt(agent.Target.Position);
            return NodeState.Success;
        }
    }
}