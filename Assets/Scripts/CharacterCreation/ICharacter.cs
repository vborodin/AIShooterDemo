using UnityEngine;

namespace AIShooterDemo
{
    public interface ICharacter
    {
        float Health { get; }
        Vector3 Position { get; }
        Vector3 Destination { get; }
        void Move(Vector3 destination);
        bool IsDead { get; }
    }
}