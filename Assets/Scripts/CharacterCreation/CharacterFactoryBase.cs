using UnityEngine;

namespace AIShooterDemo
{
    public abstract class CharacterFactoryBase
    {
        public abstract ICharacter CreateCharacter(Vector3 position, string team, LevelDataBase levelData, float difficultyModifier, params ICharacterPreset[] characterPresets);

        public static CharacterFactoryBase Create(string factoryType)
        {
            CharacterFactoryBase factory;
            switch (factoryType)
            {
                case "MockupFactory":
                    factory = new MockupCharacterFactory();
                    break;
                default:
                    Debug.LogWarning($"Unknown character factory type: {factoryType}");
                    factory = new MockupCharacterFactory();
                    break;
            }
            return factory;
        }
    }
}