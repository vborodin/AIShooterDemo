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
                if (agent.IsHostileTo(target) &&
                    (current == null || (target.Position - agent.Position).magnitude < (current.Position - agent.Position).magnitude))
                {
                    current = target;
                }
                if (!agent.IsHostileTo(target) &&
                    target.Target != null &&
                    agent.IsHostileTo(target.Target) &&
                    (
                        current == null ||
                        (target.Target.Position - agent.Position).magnitude < (current.Position - agent.Position).magnitude
                    )
                )
                {
                    current = target.Target;
                }
            }

            agent.Target = current;
            return NodeState.Success;
        }
    }
}