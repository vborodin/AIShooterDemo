namespace AIShooterDemo
{
    public class InverterNode : INode
    {
        INode child;

        public string Name => "Inverter";

        public InverterNode(INode child)
        {
            this.child = child;
        }

        public void Init(ICharacter agent)
        {
            child.Init(agent);
        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            NodeState state = child.Process(timeDelta, agent);
            if (state == NodeState.Success)
            {
                return NodeState.Failure;
            }
            if (state == NodeState.Failure)
            {
                return NodeState.Success;
            }
            return NodeState.Running;
        }
    }
}