using UnityEngine;

namespace AIShooterDemo
{
    public class RepeaterNode : INode
    {
        INode child;
        int iterations;
        int iterated;

        public string Name => "Repeater";

        public RepeaterNode(INode child, int iterations)
        {
            this.child = child;
            this.iterations = iterations;
        }

        public void Init(ICharacter agent)
        {
            iterated = 0;
            child.Init(agent);
        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            NodeState state = child.Process(timeDelta, agent);
            if (state == NodeState.Success || state == NodeState.Running)
            {
                return state;
            }

            iterated++;
            if (iterated > iterations)
            {
                return NodeState.Success;
            }

            Debug.Log($"{child.Name} failed, reiterate {iterated}/{iterations}");
            child.Init(agent);
            return NodeState.Running;
        }
    }
}