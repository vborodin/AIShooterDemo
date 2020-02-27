namespace AIShooterDemo
{
    public class TargetInRangeNode : INode
    {
        public string Name => "CanAttack";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (agent.TargetInRange)
            {
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}