using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class Settings : ScriptableObject
    {
        [SerializeField] private string levelProvider = "Mockup";
        public string LevelProvider => levelProvider;

        [SerializeField] private string playerType = "Mockup";
        public string PlayerType => playerType;

        [SerializeField] private string solverType = "PassThrough";
        public string SolverType => solverType;

        [SerializeField] private float distanceEpsilon = 1.5f;
        public float DistanceEpsilon => distanceEpsilon;
    }
}