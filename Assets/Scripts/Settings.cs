using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class Settings : ScriptableObject
    {
        [SerializeField] private string levelProvider = "Mockup";
        public string LevelProvider => levelProvider;

        [SerializeField] private ScriptableCharacterPreset[] playerCharacters = new ScriptableCharacterPreset[0];
        public ICharacterPreset[] PlayerCharacters => playerCharacters;

        [SerializeField] private string playerFactoryType = "MockupFactory";
        public string PlayerFactoryType => playerFactoryType;

        [SerializeField] private string solverType = "PassThrough";
        public string SolverType => solverType;

        [SerializeField] private float distanceEpsilon = 1.5f;
        public float DistanceEpsilon => distanceEpsilon;

        [SerializeField] private float cameraVelocity = 10f;
        public float CameraVelocity => cameraVelocity;

        [SerializeField] private Vector3 cameraPosition = new Vector3(3, 10, 3);
        public Vector3 CameraPosition => cameraPosition;

        [SerializeField] private float difficultyProgression = 1.5f;
        public float DifficultyProgression => difficultyProgression;
    }
}