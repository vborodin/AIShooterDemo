using UnityEngine;

namespace AIShooterDemo
{
    public class GameSolverFactory
    {
        ILevelData levelData;
        Settings settings;
        public GameSolverFactory(ILevelData levelData, Settings settings)
        {
            this.levelData = levelData;
            this.settings = settings;
        }

        public IGameSolver CreateGameSolver(string solverType)
        {
            IGameSolver solver;
            switch (solverType)
            {
                case "PassThrough":
                    solver = new PassThroughGameSolver(levelData.Destination, settings.DistanceEpsilon);
                    break;
                default:
                    Debug.LogWarning($"Unknown game solver type: {solverType}");
                    solver = new PassThroughGameSolver(levelData.Destination, settings.DistanceEpsilon);
                    break;
            }
            return solver;
        }
    }
}