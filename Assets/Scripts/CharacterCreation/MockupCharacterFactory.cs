using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class MockupCharacterFactory : CharacterFactoryBase
    {
        public override ICharacter CreateCharacter(Vector3 position, string team, LevelDataBase levelData, params ICharacterPreset[] characterPresets)
        {
            if (characterPresets.Length == 0)
            {
                return new NullCharacter();
            }
            if (characterPresets.Length == 1)
            {
                return CreateSingleCharacter(position, team, levelData, characterPresets[0]);
            }

            List<ICharacter> characters = new List<ICharacter>();
            foreach (ICharacterPreset preset in characterPresets)
            {
                characters.Add(CreateSingleCharacter(position, team, levelData, preset));
            }
            GameObject teamCharacter = new GameObject();
            TeamCharacter character = teamCharacter.AddComponent<TeamCharacter>();
            character.Init(characters);
            return character;
        }

        private ICharacter CreateSingleCharacter(Vector3 position, string team, LevelDataBase levelData, ICharacterPreset preset)
        {
            CharacterData characterData = Resources.Load<CharacterData>($"Characters/{preset.CharacterData}");
            if (characterData == null)
            {
                Debug.LogWarning($"Character data for {preset.CharacterData} not found.");
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
            charComponent.Init(characterData, levelData, team);
            ControllerBase.AddComponent(character, levelData, preset.BehaviourType, preset.BehaviourTemplate);

            return charComponent;
        }
    }
}