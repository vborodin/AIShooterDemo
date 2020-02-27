using UnityEngine;

namespace AIShooterDemo
{
    public abstract class LevelDataBase : MonoBehaviour
    {
        public abstract Vector3 StartPosition { get; }
        public abstract Vector3 Destination { get; }

        public abstract bool IsFinished { get; }
        public abstract void SetData(IGameSolver gameSolver);

        protected virtual void Start()
        {
            Init();
        }

        protected abstract void Init();
    }
}