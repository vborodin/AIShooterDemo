using UnityEngine;

namespace AIShooterDemo
{
    public interface IAbilityData
    {
        string AbilityName { get; }
        float Cost { get; }
        float Damage { get; }
        GameObject View { get; }
    }
}