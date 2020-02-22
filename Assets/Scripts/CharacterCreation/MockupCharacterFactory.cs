using UnityEngine;

namespace AIShooterDemo
{
    public class MockupCharacterFactory : ICharacterFactory
    {
        private LevelData data;
        public MockupCharacterFactory(LevelData data)
        {
            this.data = data;
        }

        public GameObject CreateCharacter()
        {
            var character = GameObject.Instantiate(Resources.Load<GameObject>("MockupCharacter"));
            var characterComponent = character.AddComponent<MockupCharacter>();
            characterComponent.SetData(new MockupCharacterData() { destination = data.EndPosition });

            return character;
        }
    }
}