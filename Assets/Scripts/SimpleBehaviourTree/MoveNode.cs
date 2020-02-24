using UnityEngine;

namespace AIShooterDemo
{
    public class MoveNode : INode
    {
        Vector3 destination;
        float distanceEpsilon;
        float maxTime;
        float spentTime;

        public MoveNode(Vector3 destination, float distanceEpsilon, float maxTime)
        {
            this.destination = destination;
            this.distanceEpsilon = distanceEpsilon;
            this.maxTime = maxTime;
        }

        public void Init(ICharacter context)
        {
            spentTime = 0;
            context.Move(destination);
        }

        public NodeState Process(float timeDelta, ICharacter context)
        {
            spentTime += timeDelta;
            if ((context.Position - destination).magnitude < distanceEpsilon)
            {
                context.Move(context.Position);
                return NodeState.Success;
            }

            if (spentTime < maxTime)
            {
                return NodeState.Running;
            }

            context.Move(context.Position);
            return NodeState.Failure;
        }
    }
}