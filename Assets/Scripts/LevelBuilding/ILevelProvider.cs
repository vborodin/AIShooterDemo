using UnityEngine;

namespace AIShooterDemo
{
    public interface ILevelProvider
    {
        GameObject Next();
    }
}