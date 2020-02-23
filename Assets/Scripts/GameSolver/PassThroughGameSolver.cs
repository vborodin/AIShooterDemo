using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class PassThroughGameSolver : IGameSolver
    {
        public ICollection<string> InputParams => inputParams;
        string[] inputParams = new string[2] { "position", "health" };

        public GameState State => state;
        GameState state = GameState.InProgress;

        Vector3 destination;
        float delta;

        public PassThroughGameSolver(Vector3 destination, float distanceDelta)
        {
            this.destination = destination;
            this.delta = distanceDelta;
        }

        public GameState Update(GameSolverData input)
        {
            if (input.GetValue<float>("health") <= 0)
            {
                state = GameState.Loss;
            }
            else if ((input.GetValue<Vector3>("position") - destination).magnitude < delta)
            {
                state = GameState.Win;
            }
            else
            {
                state = GameState.InProgress;
            }
            return state;
        }
    }
}