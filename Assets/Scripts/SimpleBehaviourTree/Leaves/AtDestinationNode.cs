namespace AIShooterDemo
{
    public class AtDestinationNode : INode
    {
        public string Name => "AtDestination";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (agent.AtDestination)
            {
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}