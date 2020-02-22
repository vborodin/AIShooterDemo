using UnityEngine;

namespace AIShooterDemo
{
    interface ICharacterFactory
    {
        GameObject CreateCharacter();
    }
}