namespace AIShooterDemo
{
    public class TurnAroundNode : INode
    {
        public string Name => "TurnAround";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            agent.LookAt(agent.Position - agent.LookVector);
            return NodeState.Success;
        }
    }
}