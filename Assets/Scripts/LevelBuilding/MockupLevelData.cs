using UnityEngine;

namespace AIShooterDemo
{
    public class MockupLevelData : MonoBehaviour, ILevelData
    {
        [SerializeField] Transform startPosition = null;
        [SerializeField] Transform endPosition = null;

        public Vector3 StartPosition => startPosition ? startPosition.position : Vector3.zero;
        public Vector3 Destination => endPosition ? endPosition.position : Vector3.zero;
    }
}