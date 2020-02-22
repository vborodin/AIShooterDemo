using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class GameManager : MonoBehaviour
    {
        private void Start()
        {
            Settings settings = Resources.Load<Settings>("Settings");
            IEnumerator<GameObject> levels = LoadLevels(settings.LevelProvider);

            if (levels.MoveNext())
            {
                GameObject level = Instantiate(levels.Current);
                LevelData levelData = level.GetComponent<LevelData>();

                CreatePlayer(settings.PlayerType, levelData);
            }
        }

        private GameObject CreatePlayer(string playerType, LevelData levelData)
        {
            ICharacterFactory characterFactory;
            switch (playerType)
            {
                case "Mockup":
                    characterFactory = new MockupCharacterFactory(levelData);
                    break;
                default:
                    characterFactory = new MockupCharacterFactory(levelData);
                    Debug.LogWarning($"Unknown player type: {playerType}");
                    break;
            }
            GameObject player = characterFactory.CreateCharacter(levelData.StartPosition);

            return player;
        }

        private IEnumerator<GameObject> LoadLevels(string providerName)
        {
            ILevelProviderFactory factory;
            switch (providerName)
            {
                case "Mockup":
                    factory = new MockupLevelProviderFactory();
                    break;
                default:
                    factory = new MockupLevelProviderFactory();
                    Debug.LogWarning($"Unknown level provider: {providerName}");
                    break;
            }
            ILevelProvider levelProvider = factory.GetLevelProvider();
            return levelProvider.GetEnumerator();
        }
    }
}