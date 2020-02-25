using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class SpawnPointData : ScriptableObject
    {
        [SerializeField] private float timeout = 5f;
        public float Timeout => timeout;

        [SerializeField] private string characterType = "MockupCharacter";
        public string CharacterType => characterType;

        [SerializeField] private string characterBehaviourType = "AI";
        public string CharacterBehaviourType => characterBehaviourType;

        [SerializeField] private string characterBehaviourTemplate = "Walker";
        public string CharacterBehaviourTemplate => characterBehaviourTemplate;

        [SerializeField] private string characterFactoryType = "MockupFactory";
        public string CharacterFactoryType => characterFactoryType;

        [SerializeField] private string team = "Enemies";
        public string Team => team;

        [SerializeField] private string characterName = "Mockup";
        public string CharacterName => characterName;
    }
}