using System.Collections;
using UnityEngine;

namespace AIShooterDemo
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] SpawnPointData data = null;
        ICharacter spawned;
        CharacterFactoryBase factory;
        LevelDataBase levelData;
        GameManager gameManager;

        private void Start()
        {
            levelData = GetComponentInParent<LevelDataBase>();
            factory = CharacterFactoryBase.Create(data.CharacterFactoryType);
            gameManager = FindObjectOfType<GameManager>();
            spawned = factory.CreateCharacter(transform.position, data.Team, levelData, gameManager.Difficulty, data.RandomPreset);
            StartCoroutine(SpawnCoroutine());
        }

        private IEnumerator SpawnCoroutine()
        {
            while (!levelData.IsFinished)
            {
                if (spawned == null || spawned.IsDead)
                {
                    yield return new WaitForSeconds(data.Timeout);
                    if (!levelData.IsFinished)
                    {
                        spawned = factory.CreateCharacter(transform.position, data.Team, levelData, gameManager.Difficulty, data.RandomPreset);
                    }
                }
                yield return new WaitForSeconds(1);
            }
            if (spawned != null && !spawned.IsDead)
            {
                spawned.TakeDamage(spawned.Health * 2, new NullCharacter());
            }
        }
    }
}