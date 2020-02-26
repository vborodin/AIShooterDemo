using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class CharacterData : ScriptableObject
    {
        public float Health => health;
        [SerializeField] private float health = 100;

        public float Damage => damage;
        [SerializeField] private float damage = 1;

        public float AttackDistance => attackDistance;
        [SerializeField] private float attackDistance = 1;

        public float Speed => speed;
        [SerializeField] private float speed = 1;

        public float FOV => fov;
        [SerializeField] private float fov = 60;

        public float FullFOVDistance => fullFOVDistance;
        [SerializeField] private float fullFOVDistance = 3;

        public GameObject Prefab => prefab;
        [SerializeField] private GameObject prefab = null;
    }
}