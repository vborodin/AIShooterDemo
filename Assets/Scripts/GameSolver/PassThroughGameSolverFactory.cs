using UnityEngine;

namespace AIShooterDemo
{
    public class PassThroughGameSolverFactory : IGameSolverFactory
    {
        Vector3 destination;
        float distanceDelta;
        public PassThroughGameSolverFactory(Vector3 destination, float distanceDelta)
        {
            this.destination = destination;
            this.distanceDelta = distanceDelta;
        }

        public IGameSolver CreateGameSolver()
        {
            return new PassThroughGameSolver(destination, distanceDelta);
        }
    }
}