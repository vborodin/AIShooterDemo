using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject playerPrefab = null;

        void Start()
        {
            //load settings
            Settings settings = Resources.Load<Settings>("Settings");

            //create factory
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

            //get levelProvider
            ILevelProvider levelProvider = factory.GetLevelProvider();
            IEnumerator<GameObject> levels = levelProvider.GetEnumerator();

            //create first level
            if (levels.MoveNext())
            {
                var level = Instantiate(levels.Current);

                //create player and set destination
                var levelData = level.GetComponent<LevelData>();
                Instantiate(playerPrefab).GetComponent<MoveTo>().Init(levelData.StartPosition, levelData.EndPosition);
            }
        }
    }
}