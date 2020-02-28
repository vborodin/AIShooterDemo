using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class SpawnPointData : ScriptableObject
    {
        [SerializeField] private float timeout = 5f;
        public float Timeout => timeout;

        [SerializeField] private ScriptableCharacterPreset[] spawnPool = new ScriptableCharacterPreset[0];
        public ICollection<ICharacterPreset> SpawnPool => spawnPool;
        public ICharacterPreset RandomPreset
        {
            get
            {
                if (spawnPool.Length == 0)
                {
                    Debug.LogWarning("Spawn pool is empty.");
                    return new NullCharacterPreset();
                }
                return spawnPool[Random.Range(0, spawnPool.Length)];
            }
        }

        [SerializeField] private string characterFactoryType = "MockupFactory";
        public string CharacterFactoryType => characterFactoryType;

        [SerializeField] private string team = "Enemies";
        public string Team => team;
    }
}