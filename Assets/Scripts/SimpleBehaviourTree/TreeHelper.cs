using UnityEngine;

namespace AIShooterDemo
{
    public static class TreeHelper
    {
        public static INode CreateBehaviourTemplate(string behaviourTemplate, Vector3 destination)
        {
            INode tree;
            switch (behaviourTemplate)
            {
                case "Player":
                    tree = PlayerBehaviour();
                    break;
                case "Zombie":
                    tree = ZombieBehaviour();
                    break;
                default:
                    Debug.LogWarning($"Unknown behaviour template: {behaviourTemplate}");
                    tree = new NullNode();
                    break;
            }
            return tree;
        }

        private static INode PlayerBehaviour()
        {
            return new SelectorNode(
                FallbackCheck(),
                FindAndAttackTarget(),
                new InverterNode(
                    new RestoreDestinationNode()
                ),
                new AtDestinationNode(),
                MoveAlongPath()
            );
        }

        private static INode ZombieBehaviour()
        {
            return new SelectorNode(
                FindAndAttackTarget(),
                RandomMovement(2)
            );
        }

        private static INode FallbackCheck()
        {
            return new SequenceNode(
                new TargetValidationNode(),
                new InverterNode(
                    new AtDestinationNode()
                ),
                new AskByTimeoutNode(
                    new SequenceNode(
                        new NeedFallbackNode(),
                        new FallbackPositionNode()
                    ), 2f
                ),
                MoveAlongPath()
            );
        }

        private static INode MoveAlongPath()
        {
            return new SequenceNode(
                new LookAlongPathNode(),
                new MoveForwardNode()
            );
        }

        private static INode FindAndAttackTarget()
        {
            return new SequenceNode(
                    new SelectorNode(
                        new TargetValidationNode(),
                        new FindEnemyNode()
                    ),
                    new SelectorNode(
                        new SequenceNode(
                            new TargetInRangeNode(),
                            new LookAtTargetNode(),
                            new AttackNode()
                        ),
                        new SequenceNode(
                            new DestinationToTargetNode(),
                            MoveAlongPath()
                        )
                    )
            );
        }

        private static INode RandomMovement(float time)
        {
            return new SequenceNode(
                new InverterNode(
                    new TimeRepeaterNode(
                        MoveAlongPath(), time
                    )
                ),
                new RandomDestinationNode()
            );
        }
    }
}