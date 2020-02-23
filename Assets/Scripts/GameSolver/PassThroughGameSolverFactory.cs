using UnityEngine;

namespace AIShooterDemo
{
    public class PassThroughGameSolverFactory : IGameSolverFactory
    {
        Vector3 destination;
        float distanceEpsilon;
        public PassThroughGameSolverFactory(Vector3 destination, float distanceEpsilon)
        {
            this.destination = destination;
            this.distanceEpsilon = distanceEpsilon;
        }

        public IGameSolver CreateGameSolver()
        {
            return new PassThroughGameSolver(destination, distanceEpsilon);
        }
    }
}