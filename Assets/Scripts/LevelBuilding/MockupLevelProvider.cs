using UnityEngine;

namespace AIShooterDemo
{
    public class MockupLevelProvider : ILevelProvider
    {
        public string SourceDirectory { get; private set; }

        public MockupLevelProvider(string sourceDirectory)
        {
            SourceDirectory = sourceDirectory;
        }

        public GameObject Next()
        {
            return Resources.Load<GameObject>($"{SourceDirectory}/MockupLevel");
        }
    }
}