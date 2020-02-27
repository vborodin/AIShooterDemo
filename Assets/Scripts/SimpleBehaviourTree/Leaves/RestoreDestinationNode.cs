namespace AIShooterDemo
{
    public class RestoreDestinationNode : INode
    {
        public string Name => "RestoreDestination";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            agent.RestoreDestination();
            return NodeState.Success;
        }
    }
}