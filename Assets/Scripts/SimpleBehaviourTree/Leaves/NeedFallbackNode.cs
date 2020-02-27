namespace AIShooterDemo
{
    public class NeedFallbackNode : INode
    {
        public string Name => "NeedFallback";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (!agent.TargetInRange)
            {
                return NodeState.Failure;
            }
            if ((agent.Target.Position - agent.Position).magnitude < agent.AttackRange / 3)
            {
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}