using UnityEngine;

namespace AIShooterDemo
{
    public class MockupCharacterFactory : CharacterFactoryBase
    {
        public override ICharacter CreateCharacter(Vector3 position, string characterType, string behaviourType, string behaviourTemplate, ILevelData levelData)
        {
#warning too many responsibilities
            CharacterData characterData = Resources.Load<CharacterData>($"Characters/{characterType}");

            GameObject character = GameObject.Instantiate(characterData.Prefab, position, Quaternion.identity);
            SingleCharacter charComponent = character.AddComponent<SingleCharacter>();
            charComponent.Init(characterData, levelData);

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
                    controller.SetData(new MoveNode(charComponent.Position, float.PositiveInfinity, 0f));
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
                    tree = new RepeaterNode(new MoveNode(destination, 1.5f, 2), 20);
                    break;
                default:
                    Debug.LogWarning($"Unknown behaviour template: {behaviourTemplate}");
                    tree = new RepeaterNode(new MoveNode(destination, 1.5f, 2), 10);
                    break;
            }
            return tree;
        }
    }
}