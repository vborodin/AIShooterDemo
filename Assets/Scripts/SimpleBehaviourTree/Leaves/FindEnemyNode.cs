using System.Collections.Generic;
using System.Linq;

namespace AIShooterDemo
{
    public class FindEnemyNode : INode
    {
        public string Name => "FindEnemy";
        public void Init(ICharacter agent)
        {

        }

        public NodeState Process(float timeDelta, ICharacter agent)
        {
            IEnumerable<ICharacter> possibleTargets = agent.Watch();
            if (possibleTargets.Count() == 0)
            {
                agent.Target = null;
                return NodeState.Failure;
            }
            //closest hostile character
            ICharacter current = agent.Target;
            foreach (ICharacter target in possibleTargets)
            {
                if (target.IsHostileTo(agent) &&
                    (current == null || (target.Position - agent.Position).magnitude < (current.Position - agent.Position).magnitude))
                {
                    current = target;
                }
            }

            agent.Target = current;
            return NodeState.Success;
        }
    }
}