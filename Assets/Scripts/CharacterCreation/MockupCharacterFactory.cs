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

        public GameObject CreateCharacter(Vector3 position)
        {
            var character = GameObject.Instantiate(Resources.Load<GameObject>("MockupCharacter"));
            var characterComponent = character.AddComponent<MockupCharacter>();
            characterComponent.SetData(new MockupCharacterData() { destination = data.EndPosition });
            character.transform.position = position;

            return character;
        }
    }
}