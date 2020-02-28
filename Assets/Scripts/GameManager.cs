using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AIShooterDemo
{
    public class GameManager : MonoBehaviour
    {
        public Settings Settings => settings;
        Settings settings;
        public ICharacter Player => player;
        public float Difficulty { get; private set; }
        ICharacter player;
        IEnumerator<GameObject> levels;
        IGameSolver solver;
        UIManagerBase uiManager;

        private void Start()
        {
            settings = Resources.Load<Settings>("Settings");
            levels = LoadLevels(settings.LevelProvider);
            uiManager = FindObjectOfType<UIManagerBase>();
            Difficulty = 1.0f;
            Restart();
        }

        private void Cleanup()
        {
            IEnumerable<ICharacter> characters = FindObjectsOfType<MonoBehaviour>().OfType<ICharacter>();
            foreach (ICharacter character in characters)
            {
                Destroy(((MonoBehaviour)character).gameObject);
            }
            IEnumerable<LevelDataBase> levelDatas = FindObjectsOfType<LevelDataBase>();
            foreach (LevelDataBase levelData in levelDatas)
            {
                Destroy((levelData).gameObject);
            }
            IEnumerable<Collider> colliders = FindObjectsOfType<Collider>();
            foreach (Collider collider in colliders)
            {
                Destroy(collider.gameObject);
            }
        }

        private void Restart()
        {
            Cleanup();
            if (levels.MoveNext())
            {
                GameObject level = Instantiate(levels.Current);
                LevelDataBase levelData = level.GetComponent<LevelDataBase>();
                if (levelData == null)
                {
                    Debug.LogWarning("Level doesn't contain any LevelData");
                }

                CharacterFactoryBase characterFactory = CharacterFactoryBase.Create(settings.PlayerFactoryType);
                player = characterFactory.CreateCharacter(levelData.StartPosition, "Player", levelData, 1.0f, settings.PlayerCharacters);

                solver = CreateGameSolver(settings.SolverType, levelData, settings);
                levelData.SetData(solver);
            }
        }

        private IEnumerator RestartCoroutine(float timeout)
        {
            yield return new WaitForSeconds(timeout);
            Restart();
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
                    Difficulty *= settings.DifficultyProgression;
                    StartCoroutine(RestartCoroutine(5f));
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

        private IEnumerator<GameObject> LoadLevels(string providerName)
        {
            LevelProviderBase levelProvider = LevelProviderBase.Create(providerName);
            return levelProvider.GetEnumerator();
        }
    }
}