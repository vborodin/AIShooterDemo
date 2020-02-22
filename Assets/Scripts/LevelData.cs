using UnityEngine;

namespace AIShooterDemo
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] Transform startPosition = null;
        [SerializeField] Transform endPosition = null;

        public Vector3 StartPosition => startPosition ? startPosition.position : Vector3.zero;
        public Vector3 EndPosition => endPosition ? endPosition.position : Vector3.zero;
    }
}