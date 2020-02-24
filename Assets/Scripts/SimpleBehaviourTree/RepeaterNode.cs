using UnityEngine;

namespace AIShooterDemo
{
    public class RepeaterNode : INode
    {
        INode child;
        int iterations;
        int iterated;

        public RepeaterNode(INode child, int iterations)
        {
            this.child = child;
            this.iterations = iterations;
        }

        public void Init(ICharacter context)
        {
            iterated = 0;
            child.Init(context);
            Debug.Log("Repeater init");
        }

        public NodeState Process(float timeDelta, ICharacter context)
        {
            NodeState state = child.Process(timeDelta, context);
            if (state == NodeState.Success || state == NodeState.Running)
            {
                return state;
            }

            iterated++;
            if (iterated >= iterations)
            {
                return NodeState.Success;
            }

            Debug.Log($"Child failed, reiterate {iterated}/{iterations}");
            child.Init(context);
            return NodeState.Running;
        }
    }
}