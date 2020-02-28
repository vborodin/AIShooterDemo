using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class SpawnPointData : ScriptableObject
    {
        [SerializeField] private float timeout = 5f;
        public float Timeout => timeout;

        [SerializeField] private string[] characterTypePool = new string[] { "Zombie" };
        public string CharacterType
        {
            get
            {
                if (characterTypePool == null || characterTypePool.Length == 0)
                {
                    return "";
                }
                return characterTypePool[Random.Range(0, characterTypePool.Length)];
            }
        }

        [SerializeField] private string characterBehaviourType = "AI";
        public string CharacterBehaviourType => characterBehaviourType;

        [SerializeField] private string characterBehaviourTemplate = "Zombie";
        public string CharacterBehaviourTemplate => characterBehaviourTemplate;

        [SerializeField] private string characterFactoryType = "MockupFactory";
        public string CharacterFactoryType => characterFactoryType;

        [SerializeField] private string team = "Enemies";
        public string Team => team;

        [SerializeField] private string characterName = "Mockup";
        public string CharacterName => characterName;
    }
}