namespace AIShooterDemo
{
    public class AskByTimeoutNode : INode
    {
        public string Name => "AskByTimeout";
        private float maxTime;
        private float timer;
        NodeState prevState = NodeState.Failure;
        INode child;

        public AskByTimeoutNode(INode child, float timeout)
        {
            maxTime = timeout;
            this.child = child;
        }

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            timer += timeDelta;
            if (timer >= maxTime)
            {
                prevState = child.Process(timeDelta, agent);
                timer = 0;
            }
            return prevState;
        }
    }
}