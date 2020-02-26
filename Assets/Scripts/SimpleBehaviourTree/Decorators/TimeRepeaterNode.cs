namespace AIShooterDemo
{
    public class TimeRepeaterNode : INode
    {
        public string Name => "TimeRepeater";

        INode child;
        float repeatTime;
        float timeSpent;

        public TimeRepeaterNode(INode child, float time)
        {
            this.child = child;
            repeatTime = time;
        }

        public void Init(ICharacter agent)
        {
            timeSpent = 0;
            child.Init(agent);
        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (timeSpent > repeatTime)
            {
                return NodeState.Success;
            }
            child.Process(timeDelta, agent);
            timeSpent += timeDelta;
            return NodeState.Running;
        }
    }
}