namespace AIShooterDemo
{
    public class CastAbilityNode : INode
    {
        public string Name => "CastAbility";

        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            if (agent.Target != null && agent.CanCastAbility())
            {
                agent.CastAbility(agent.Target);
                return NodeState.Success;
            }
            return NodeState.Failure;
        }
    }
}