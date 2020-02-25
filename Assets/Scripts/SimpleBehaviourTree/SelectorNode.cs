using System.Collections.Generic;
using System.Linq;

namespace AIShooterDemo
{
    public class SelectorNode : INode
    {
        ICollection<INode> children;

        public string Name => "Selector";

        public SelectorNode(ICollection<INode> children)
        {
            this.children = children;
        }

        public void Init(ICharacter agent)
        {
            foreach (INode child in children)
            {
                child.Init(agent);
            }
        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            foreach (INode child in children)
            {
                NodeState state = child.Process(timeDelta, agent);
                if (state == NodeState.Success || state == NodeState.Running)
                {
                    return state;
                }
            }
            return NodeState.Failure;
        }
    }
}