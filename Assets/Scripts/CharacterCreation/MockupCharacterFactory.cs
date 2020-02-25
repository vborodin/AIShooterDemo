using UnityEngine;

namespace AIShooterDemo
{
    public class MockupCharacterFactory : CharacterFactoryBase
    {
        public override ICharacter CreateCharacter(Vector3 position, string characterType, string behaviourType, string behaviourTemplate, string name, string team, ILevelData levelData)
        {
#warning too many responsibilities
            CharacterData characterData = Resources.Load<CharacterData>($"Characters/{characterType}");

            GameObject character = GameObject.Instantiate(characterData.Prefab, position, Quaternion.identity);
            MockupCharacter charComponent = character.AddComponent<MockupCharacter>();
            charComponent.Init(characterData, levelData, name, team);

            ControllerBase controller;
            switch (behaviourType)
            {
                case "AI":
                    controller = character.AddComponent<AIController>();
                    controller.SetData(CreateBehaviourTemplate(behaviourTemplate, levelData.Destination));
                    break;
                default:
                    Debug.LogWarning($"Unknown behaviour type: {behaviourType}");
                    controller = character.AddComponent<AIController>();
                    controller.SetData(new AttackNode());
                    break;
            }

            return charComponent;
        }

        private INode CreateBehaviourTemplate(string behaviourTemplate, Vector3 destination)
        {
            INode tree;
            switch (behaviourTemplate)
            {
                case "Walker":
                    //tree = new RepeaterNode(new MoveNode(destination, 1.5f, 2), 20);
                    tree = new RepeaterNode(new SelectorNode(
                        new INode[] {
                            new SequenceNode(
                                new INode[] {
                                    new FindEnemyNode(),
                                    new LookAtTargetNode(),
                                    new AttackNode()
                                }
                            ),
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
                    tree = new LookAtTargetNode();
                    break;
            }
            return tree;
        }
    }
}