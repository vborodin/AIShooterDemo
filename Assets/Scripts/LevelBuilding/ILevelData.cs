using UnityEngine;

namespace AIShooterDemo
{
    public interface ILevelData
    {
        Vector3 StartPosition { get; }
        Vector3 Destination { get; }
    }
}