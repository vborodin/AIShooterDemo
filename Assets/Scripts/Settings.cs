using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class Settings : ScriptableObject
    {
        [SerializeField] private string levelProvider = "Mockup";
        public string LevelProvider => levelProvider;

        [SerializeField] private string playerType = "MockupCharacter";
        public string PlayerType => playerType;

        [SerializeField] private string playerBehaviourType = "AI";
        public string PlayerBehaviourType => playerBehaviourType;

        [SerializeField] private string playerBehaviourTemplate = "Walker";
        public string PlayerBehaviourTemplate => playerBehaviourTemplate;

        [SerializeField] private string playerFactoryType = "MockupFactory";
        public string PlayerFactoryType => playerFactoryType;

        [SerializeField] private string solverType = "PassThrough";
        public string SolverType => solverType;

        [SerializeField] private float distanceEpsilon = 1.5f;
        public float DistanceEpsilon => distanceEpsilon;
    }
}