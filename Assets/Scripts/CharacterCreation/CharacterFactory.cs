using UnityEngine;

namespace AIShooterDemo
{
    public class CharacterFactory
    {
        public ICharacter CreateCharacter(Vector3 position, string characterType, ILevelData levelData)
        {
            CharacterData characterData = Resources.Load<CharacterData>($"Characters/{characterType}");
            GameObject character = GameObject.Instantiate(characterData.Prefab, position, Quaternion.identity);
            SingleCharacter charComponent = character.AddComponent<SingleCharacter>();
            charComponent.Init(characterData, levelData);
            character.AddComponent<AITest>();
            return charComponent;
        }
    }
}