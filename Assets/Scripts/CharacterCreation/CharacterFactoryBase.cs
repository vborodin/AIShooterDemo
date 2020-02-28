using UnityEngine;

namespace AIShooterDemo
{
    public abstract class CharacterFactoryBase
    {
        public abstract ICharacter CreateCharacter(Vector3 position, string characterType, string behaviourType, string behaviourTemplate, string team, LevelDataBase levelData);

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