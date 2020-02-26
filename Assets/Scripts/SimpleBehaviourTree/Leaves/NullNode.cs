namespace AIShooterDemo
{
    public class NullNode : INode
    {
        public string Name => "";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            return NodeState.Success;
        }
    }
}