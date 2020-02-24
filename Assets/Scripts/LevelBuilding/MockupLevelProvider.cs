using UnityEngine;
using System.Collections.Generic;

namespace AIShooterDemo
{
    public class MockupLevelProvider : LevelProviderBase
    {
        public override IEnumerator<GameObject> GetEnumerator()
        {
            yield return Resources.Load<GameObject>("MockupLevelProvider/MockupLevel");
        }
    }
}