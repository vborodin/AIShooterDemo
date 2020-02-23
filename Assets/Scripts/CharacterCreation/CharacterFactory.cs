using UnityEngine;

namespace AIShooterDemo
{
    public class CharacterFactory
    {
        public ICharacter CreateCharacter(Vector3 position, string characterType)
        {
            CharacterData characterData = Resources.Load<CharacterData>($"Characters/{characterType}");
            GameObject character = GameObject.Instantiate(characterData.Prefab, position, Quaternion.identity);
            SingleCharacter charComponent = character.AddComponent<SingleCharacter>();
            charComponent.Init(characterData);
            return charComponent;
        }
    }
}