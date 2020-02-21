using UnityEngine;

namespace AIShooterDemo
{
    public class LevelData : MonoBehaviour
    {
#warning BAD CODE
        [SerializeField] Transform startPosition = null;
        [SerializeField] Transform endPosition = null;

        public Vector3 StartPosition => startPosition.position;
        public Vector3 EndPosition => endPosition.position;
    }
}