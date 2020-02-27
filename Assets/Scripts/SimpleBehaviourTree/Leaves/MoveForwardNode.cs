namespace AIShooterDemo
{
    public class MoveForwardNode : INode
    {
        public string Name => "MoveForward";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            agent.MoveForward(timeDelta);
            return NodeState.Success;
        }
    }
}