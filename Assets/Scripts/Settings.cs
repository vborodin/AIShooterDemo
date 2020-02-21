using UnityEngine;
using System;

namespace AIShooterDemo
{
    [CreateAssetMenu]
    public class Settings : ScriptableObject
    {
        [SerializeField] private string levelProvider = "";
        public string LevelProvider => levelProvider;
    }
}