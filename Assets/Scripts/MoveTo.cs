using UnityEngine;
using UnityEngine.AI;

namespace AIShooterDemo
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveTo : MonoBehaviour
    {

        ILevelProvider levelProvider;

        private void Awake()
        {
#warning BAD CODE
            Settings settings = Resources.Load<Settings>("Settings");

            ILevelProviderFactory factory;
            switch (settings.LevelProvider)
            {
                case "Mockup":
                    factory = new MockupLevelProviderFactory();
                    break;
                default:
                    factory = new MockupLevelProviderFactory();
                    Debug.LogWarning($"Unknown level provider: {settings.LevelProvider}");
                    break;
            }

            levelProvider = factory.GetLevelProvider();
            var level = Instantiate(levelProvider.Next());

            var agent = GetComponent<NavMeshAgent>();
            agent.enabled = true;
            var levelData = level.GetComponent<LevelData>();
            if (levelData != null)
            {
                agent.transform.position = levelData.StartPosition;
                agent.destination = levelData.EndPosition;
            }
            else
            {
                Debug.LogError("Loaded level doesn't contain any level data!");
            }
        }
    }
}