using UnityEngine;
using System.Collections.Generic;

namespace AIShooterDemo
{
    public class MockupLevelProvider : LevelProviderBase
    {
        public override IEnumerator<GameObject> GetEnumerator()
        {
            GameObject level = Resources.Load<GameObject>("MockupLevelProvider/MockupLevel");
            for (int i = 0; i < 1000; i++)
            {
                yield return level;
            }
        }
    }
}