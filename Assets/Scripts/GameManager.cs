using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class GameManager : MonoBehaviour
    {
        IEnumerator<GameObject> levels;
        ICharacter player;
        IGameSolver solver;

        private void Start()
        {
            Settings settings = Resources.Load<Settings>("Settings");
            levels = LoadLevels(settings.LevelProvider);

            if (levels.MoveNext())
            {
                GameObject level = Instantiate(levels.Current);
                ILevelData levelData = level.GetComponent<ILevelData>();
                if (levelData == null)
                {
                    Debug.LogWarning("Level doesn't contain any LevelData");
                }

                player = CreatePlayer(settings.PlayerType, settings.PlayerBehaviourType, settings.PlayerBehaviourTemplate, levelData, settings.PlayerFactoryType);

                solver = CreateGameSolver(settings.SolverType, levelData, settings);
            }
        }

        private void Update()
        {
            GameState state = solver.Update(CollectGameSolverData(solver.InputParams));
            switch (state)
            {
                case GameState.InProgress:
                    //Debug.Log("In progress...");
                    break;
                case GameState.Win:
                    Debug.Log("You win!");
                    break;
                case GameState.Loss:
                    //Debug.Log("You lose!");
                    break;
                default:
                    Debug.LogWarning($"Unknown game state: {state}");
                    break;
            }
        }

        private IGameSolver CreateGameSolver(string solverType, ILevelData levelData, Settings settings)
        {
            IGameSolverFactory gameSolverFactory;
            switch (solverType)
            {
                case "PassThrough":
                    gameSolverFactory = new PassThroughGameSolverFactory(levelData.Destination, settings.DistanceEpsilon);
                    break;
                default:
                    gameSolverFactory = new PassThroughGameSolverFactory(levelData.Destination, settings.DistanceEpsilon);
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
                        data.SetValue("health", player.Health);
                        break;
                    case "position":
                        data.SetValue("position", player.Position);
                        break;
                    default:
                        Debug.LogWarning($"Unknown GameSolverParameter: {p}");
                        break;
                }
            }
            return data;
        }

        private ICharacter CreatePlayer(string playerType, string behaviourType, string behaviourTemplate, ILevelData levelData, string factoryType)
        {
            CharacterFactoryBase characterFactory = CharacterFactoryBase.Create(factoryType);
            return characterFactory.CreateCharacter(levelData.StartPosition, playerType, behaviourType, behaviourTemplate, levelData);
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