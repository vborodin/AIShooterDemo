using UnityEngine;
using System.Collections.Generic;

namespace AIShooterDemo
{
    public abstract class LevelProviderBase
    {
        public abstract IEnumerator<GameObject> GetEnumerator();
        public static LevelProviderBase Create(string providerName)
        {
            LevelProviderBase provider;
            switch (providerName)
            {
                case "Mockup":
                    provider = new MockupLevelProvider();
                    break;
                default:
                    provider = new MockupLevelProvider();
                    Debug.LogWarning($"Unknown level provider: {providerName}");
                    break;
            }
            return provider;
        }
    }
}