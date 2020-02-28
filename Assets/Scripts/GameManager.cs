using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class GameManager : MonoBehaviour
    {
        IEnumerator<GameObject> levels;
        ICharacter player;
        IGameSolver solver;
        UIManagerBase uiManager;

        private void Start()
        {
            Settings settings = Resources.Load<Settings>("Settings");
            levels = LoadLevels(settings.LevelProvider);

            uiManager = FindObjectOfType<UIManagerBase>();

            if (levels.MoveNext())
            {
                GameObject level = Instantiate(levels.Current);
                LevelDataBase levelData = level.GetComponent<LevelDataBase>();
                if (levelData == null)
                {
                    Debug.LogWarning("Level doesn't contain any LevelData");
                }

                player = CreatePlayer(settings.PlayerType, settings.PlayerBehaviourType, settings.PlayerBehaviourTemplate, levelData, settings.PlayerFactoryType);

                solver = CreateGameSolver(settings.SolverType, levelData, settings);
                levelData.SetData(solver);
            }
        }

        private void Update()
        {
            if (solver.State != GameState.InProgress)
            {
                return;
            }
            GameState state = solver.Update(CollectGameSolverData(solver.InputParams));
            switch (state)
            {
                case GameState.InProgress:
                    //Debug.Log("In progress...");
                    break;
                case GameState.Win:
                    uiManager.ShowMessage("You win!", 5f, delegate () { Debug.Log("Test win action"); });
                    break;
                case GameState.Loss:
                    uiManager.ShowMessage("You died", 5f, delegate () { Debug.Log("Test loss action"); });
                    break;
                default:
                    Debug.LogWarning($"Unknown game state: {state}");
                    break;
            }
        }

        private IGameSolver CreateGameSolver(string solverType, LevelDataBase levelData, Settings settings)
        {
            GameSolverFactory factory = new GameSolverFactory(levelData, settings);
            IGameSolver solver = factory.CreateGameSolver(solverType);
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

        private ICharacter CreatePlayer(string playerType, string behaviourType, string behaviourTemplate, LevelDataBase levelData, string factoryType)
        {
            CharacterFactoryBase characterFactory = CharacterFactoryBase.Create(factoryType);
            return characterFactory.CreateCharacter(levelData.StartPosition, playerType, behaviourType, behaviourTemplate, "Player", "Player", levelData);
        }

        private IEnumerator<GameObject> LoadLevels(string providerName)
        {
            LevelProviderBase levelProvider = LevelProviderBase.Create(providerName);
            return levelProvider.GetEnumerator();
        }
    }
}