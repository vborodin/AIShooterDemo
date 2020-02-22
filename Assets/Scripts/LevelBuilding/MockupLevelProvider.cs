using UnityEngine;
using System.Collections.Generic;

namespace AIShooterDemo
{
    public class MockupLevelProvider : ILevelProvider
    {
        public string SourceDirectory { get; private set; }

        public MockupLevelProvider(string sourceDirectory)
        {
            SourceDirectory = sourceDirectory;
        }

        public IEnumerator<GameObject> GetEnumerator()
        {
            yield return Resources.Load<GameObject>($"{SourceDirectory}/MockupLevel");
        }
    }
}