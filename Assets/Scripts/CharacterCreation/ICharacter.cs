using UnityEngine;

namespace AIShooterDemo
{
    public interface ICharacter
    {
        float Health { get; }
        Vector3 Position { get; }
    }
}