using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class GameManager : MonoBehaviour
    {
        IEnumerator<GameObject> levels;
        GameObject player;
        IGameSolver solver;

        private void Start()
        {
            Settings settings = Resources.Load<Settings>("Settings");
            levels = LoadLevels(settings.LevelProvider);

            if (levels.MoveNext())
            {
                GameObject level = Instantiate(levels.Current);
                LevelData levelData = level.GetComponent<LevelData>();
                if (levelData == null)
                {
                    Debug.LogWarning("Level doesn't contain any LevelData");
                }

                player = CreatePlayer(settings.PlayerType, levelData);

                solver = CreateGameSolver(settings.SolverType, levelData);
            }
        }

        private void Update()
        {
            GameState state = solver.Update(CollectGameSolverData(solver.InputParams));
            switch (state)
            {
                case GameState.InProgress:
                    Debug.Log("In progress...");
                    break;
                case GameState.Win:
                    Debug.Log("You win!");
                    break;
                case GameState.Loss:
                    Debug.Log("You lose!");
                    break;
                default:
                    Debug.LogWarning($"Unknown game state: {state}");
                    break;
            }
        }

        private IGameSolver CreateGameSolver(string solverType, LevelData levelData)
        {
            IGameSolverFactory gameSolverFactory;
            switch (solverType)
            {
                case "PassThrough":
#warning constant value
                    gameSolverFactory = new PassThroughGameSolverFactory(levelData.EndPosition, 1.5f);
                    break;
                default:
                    gameSolverFactory = new PassThroughGameSolverFactory(levelData.EndPosition, 1.5f);
                    Debug.LogWarning($"Unknown solver type: {solverType}");
                    break;
            }
            IGameSolver solver = gameSolverFactory.CreateGameSolver();
            return solver;
        }

        private GameSolverData CollectGameSolverData(ICollection<string> parameters)
        {
            GameSolverData data = new GameSolverData();
            foreach (var p in parameters)
            {
                switch (p)
                {
                    case "health":
#warning constant health
                        data.SetValue("health", 100f);
                        break;
                    case "position":
                        data.SetValue("position", player.transform.position);
                        break;
                    default:
                        Debug.LogWarning($"Unknown GameSolverParameter: {p}");
                        break;
                }
            }
            return data;
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