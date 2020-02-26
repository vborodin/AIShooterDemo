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
                    tree = new RepeaterNode(new SelectorNode(
                        new INode[] {
                            new SequenceNode(
                                new INode[] {
                                    new FindEnemyNode(),
                                    new LookAtTargetNode(),
                                    new AttackNode()
                                }
                            ),
                            new AtDestinationNode(),
                            new SequenceNode(
                                new INode[] {
                                    new LookAlongPathNode(),
                                    new MoveForwardNode()
                                }
                            )
                        }
                    ),
                    int.MaxValue);
                    break;
                default:
                    Debug.LogWarning($"Unknown behaviour template: {behaviourTemplate}");
                    tree = new NullNode();
                    break;
            }
            return tree;
        }
    }
}