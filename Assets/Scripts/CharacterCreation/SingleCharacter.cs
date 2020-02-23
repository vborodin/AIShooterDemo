using UnityEngine;

namespace AIShooterDemo
{
    public class SingleCharacter : MonoBehaviour, ICharacter
    {
        public float Health { get; private set; }
        public Vector3 Position => transform.position;

        public void Init(CharacterData data)
        {
            Health = data.Health;
        }
    }
}