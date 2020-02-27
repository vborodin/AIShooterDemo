using System.Collections.Generic;

namespace AIShooterDemo
{
    public class NullGameSolver : IGameSolver
    {
        public GameState State => GameState.Loss;

        public ICollection<string> InputParams => new string[0];

        public GameState Update(GameSolverData input)
        {
            return GameState.Loss;
        }
    }
}