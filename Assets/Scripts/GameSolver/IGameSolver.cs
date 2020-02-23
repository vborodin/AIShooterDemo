using System.Collections.Generic;

namespace AIShooterDemo
{
    public interface IGameSolver
    {
        /*
        Supports single player scenarios as win by frags, time or position, loss by time or health
        Needs to be heavily refactored to support few teams

        Requires an agreement about InputParams between GameManager и GameSolver
        */
        GameState Update(GameSolverData input);
        ICollection<string> InputParams { get; }
    }
}