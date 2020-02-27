namespace AIShooterDemo
{
    public class TargetValidationNode : INode
    {
        public string Name => "TargetValidation";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (agent.Target != null && !agent.Target.IsDead)
            {
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}