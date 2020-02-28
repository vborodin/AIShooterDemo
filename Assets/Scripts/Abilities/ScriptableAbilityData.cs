using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class ScriptableAbilityData : ScriptableObject, IAbilityData
    {
        [SerializeField] private string abilityName = "Mockup";
        public string AbilityName => abilityName;

        [SerializeField] private float cost = 10;
        public float Cost => cost;

        [SerializeField] private float damage = 10000;
        public float Damage => damage;

        [SerializeField] private GameObject view = null;
        public GameObject View => view;
    }
}