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

        public float AttackRate => attackRate;
        [SerializeField] private float attackRate = 1;

        public float Speed => speed;
        [SerializeField] private float speed = 1;

        public GameObject Prefab => prefab;
        [SerializeField] private GameObject prefab = null;
    }
}