using System.Collections;
using UnityEngine;

namespace AIShooterDemo
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] SpawnPointData data;
        ICharacter spawned;
        CharacterFactoryBase factory;
        ILevelData levelData;

        private void Start()
        {
            levelData = GetComponentInParent<ILevelData>();
            factory = CharacterFactoryBase.Create(data.CharacterFactoryType);
            spawned = factory.CreateCharacter(transform.position, data.CharacterType, data.CharacterBehaviourType, data.CharacterBehaviourTemplate, data.CharacterName, data.Team, levelData);
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (true)
            {
                if (spawned == null || spawned.IsDead)
                {
                    yield return new WaitForSeconds(data.Timeout);
                    spawned = factory.CreateCharacter(transform.position, data.CharacterType, data.CharacterBehaviourType, data.CharacterBehaviourTemplate, data.CharacterName, data.Team, levelData);
                }
                yield return new WaitForSeconds(1);
            }
        }
    }
}