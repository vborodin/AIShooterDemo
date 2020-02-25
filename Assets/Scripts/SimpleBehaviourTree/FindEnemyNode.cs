using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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
            ICharacter enemy = possibleTargets.Aggregate((cur, x) =>
                                (
                                    cur == null ||
                                    (
                                        x.IsHostileTo(agent) &&
                                        (x.Position - agent.Position).magnitude < (cur.Position - agent.Position).magnitude
                                    )
                                ) ? x : cur);
            agent.Target = enemy;
            return NodeState.Success;
        }
    }
}