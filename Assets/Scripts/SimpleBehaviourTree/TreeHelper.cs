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
                case "Walker":
                    tree = new SelectorNode(
                        new INode[] {
                            AttackVisibleEnemy(),
                            new AtDestinationNode(),
                            MoveAlongPath()
                        }
                    );
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

        private static INode ZombieBehaviour()
        {
            return new SelectorNode(
                new INode[] {
                    AttackVisibleEnemy(),
                    RandomMovement()
                }
            );
        }

        private static INode MoveAlongPath()
        {
            return new SequenceNode(
                new INode[] {
                    new LookAlongPathNode(),
                    new MoveForwardNode()
                }
            );
        }

        private static INode AttackVisibleEnemy()
        {
            return new SequenceNode(
                new INode[] {
                    new FindEnemyNode(),
                    new LookAtTargetNode(),
                    new SelectorNode(
                        new INode[] {
                            new SequenceNode(
                                new INode[] {
                                    new TargetInRangeNode(),
                                    new AttackNode()
                                }
                            ),
                            new MoveForwardNode()
                        }
                    )
                }
            );
        }

        private static INode RandomMovement()
        {
            return new SequenceNode(
                new INode[] {
                    new TimeRepeaterNode(
                        MoveAlongPath(), 5f
                    ),
                    new RandomDestinationNode()
                }
            );
        }
    }
}