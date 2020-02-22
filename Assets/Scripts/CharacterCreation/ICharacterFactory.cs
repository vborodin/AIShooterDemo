using UnityEngine;

namespace AIShooterDemo
{
    interface ICharacterFactory
    {
        GameObject CreateCharacter(Vector3 position);
    }
}