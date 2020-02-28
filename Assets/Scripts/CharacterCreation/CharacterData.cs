using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class CharacterData : ScriptableObject
    {
        public string Name => characterName;
        [SerializeField] private string characterName = "Name";

        public float Health => health;
        [SerializeField] private float health = 100f;

        public float RandomizedDamage => Random.Range(0.5f * damage, 1.5f * damage);
        [SerializeField] private float damage = 1f;

        public float PowerPerHit => powerPerHit;
        [SerializeField] private float powerPerHit = 1f;

        public ScriptableAbilityData AbilityData => abilityData;
        [SerializeField] private ScriptableAbilityData abilityData = null;

        public float AttackDistance => attackDistance;
        [SerializeField] private float attackDistance = 1f;

        public float AttackRate => attackRate;
        [SerializeField] private float attackRate = 2f;

        public float Speed => speed;
        [SerializeField] private float speed = 1f;

        public float FOV => fov;
        [SerializeField] private float fov = 60f;

        public float FullFOVDistance => fullFOVDistance;
        [SerializeField] private float fullFOVDistance = 2f;

        public GameObject Prefab => prefab;
        [SerializeField] private GameObject prefab = null;
    }
}