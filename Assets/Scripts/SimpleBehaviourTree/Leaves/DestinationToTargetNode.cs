namespace AIShooterDemo
{
    public class DestinationToTargetNode : INode
    {
        public string Name => "DestinationToTarget";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (agent.Target == null)
            {
                return NodeState.Failure;
            }
            agent.SetDestination(agent.Target.Position);
            return NodeState.Success;
        }
    }
}