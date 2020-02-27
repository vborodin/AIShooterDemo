using UnityEngine;

namespace AIShooterDemo
{
    public class MockupLevelData : LevelDataBase
    {
        [SerializeField] Transform startPosition = null;
        [SerializeField] Transform endPosition = null;
        IGameSolver solver;

        public override Vector3 StartPosition => startPosition ? startPosition.position : Vector3.zero;
        public override Vector3 Destination => endPosition ? endPosition.position : Vector3.zero;

        public override bool IsFinished { get => solver.State != GameState.InProgress; }

        public override void SetData(IGameSolver gameSolver)
        {
            solver = gameSolver;
        }

        protected override void Init()
        {
            if (solver == null)
            {
                solver = new NullGameSolver();
                Debug.LogWarning("GameSolver is not set. Use SetData method to set it right after creation.");
            }
        }
    }
}