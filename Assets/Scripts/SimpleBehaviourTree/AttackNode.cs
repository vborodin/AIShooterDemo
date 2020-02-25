namespace AIShooterDemo
{
    public class AttackNode : INode
    {
        public string Name => "AttackTarget";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (agent.Target == null || agent.Target.IsDead)
            {
                return NodeState.Success;
            }

            agent.Attack();
            return NodeState.Running;
        }
    }
}