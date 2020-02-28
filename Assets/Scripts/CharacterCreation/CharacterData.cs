using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class CharacterData : ScriptableObject
    {
        public string Name => characterName;
        [SerializeField] private string characterName = "Name";

        public float Health => health;
        [SerializeField] private float health = 100;

        public float RandomizedDamage => Random.Range(0.5f * damage, 1.5f * damage);
        [SerializeField] private float damage = 1;

        public float AttackDistance => attackDistance;
        [SerializeField] private float attackDistance = 1;

        public float AttackRate => attackRate;
        [SerializeField] private float attackRate = 2;

        public float Speed => speed;
        [SerializeField] private float speed = 1;

        public float FOV => fov;
        [SerializeField] private float fov = 60;

        public float FullFOVDistance => fullFOVDistance;
        [SerializeField] private float fullFOVDistance = 2;

        public GameObject Prefab => prefab;
        [SerializeField] private GameObject prefab = null;
    }
}