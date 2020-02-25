using System.Collections.Generic;
using System.Linq;

namespace AIShooterDemo
{
    public class SequenceNode : INode
    {
        ICollection<INode> children;

        public string Name => "Sequence";

        public SequenceNode(ICollection<INode> children)
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
                if (state == NodeState.Failure || state == NodeState.Running)
                {
                    return state;
                }
            }
            return NodeState.Success;
        }
    }
}