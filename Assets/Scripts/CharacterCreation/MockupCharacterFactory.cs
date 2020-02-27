using UnityEngine;

namespace AIShooterDemo
{
    public class MockupCharacterFactory : CharacterFactoryBase
    {
        public override ICharacter CreateCharacter(Vector3 position, string characterType, string controllerType, string behaviourTemplate, string name, string team, LevelDataBase levelData)
        {
            //to get CharacterData from another sources implement another factory
            CharacterData characterData = Resources.Load<CharacterData>($"Characters/{characterType}");
            if (characterData == null)
            {
                Debug.LogWarning($"Character data for {characterType} not found.");
                return new NullCharacter();
            }
            GameObject character = GameObject.Instantiate(characterData.Prefab, position, Quaternion.identity);

            ICharacter charComponent = character.GetComponent<ICharacter>();
            if (charComponent == null)
            {
                Debug.LogWarning("Character prefab requires ICharacter component.");
                GameObject.Destroy(character);
                return new NullCharacter();
            }
            charComponent.Init(characterData, levelData, name, team);
            ControllerBase.AddComponent(character, levelData, controllerType, behaviourTemplate);

            return charComponent;
        }
    }
}