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

        [SerializeField] private string playerBehaviour = "AI";
        public string PlayerBehaviour => playerBehaviour;

        [SerializeField] private string playerBehaviourTemplate = "Walker";
        public string PlayerBehaviourTemplate => playerBehaviourTemplate;

        [SerializeField] private string solverType = "PassThrough";
        public string SolverType => solverType;

        [SerializeField] private float distanceEpsilon = 1.5f;
        public float DistanceEpsilon => distanceEpsilon;
    }
}