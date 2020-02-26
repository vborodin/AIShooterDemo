using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class ZombieCharacter : MonoBehaviour, ICharacter
    {
        public string Name => throw new System.NotImplementedException();

        public float Health => throw new System.NotImplementedException();

        public Vector3 Position => throw new System.NotImplementedException();

        public Vector3 Destination => throw new System.NotImplementedException();

        public bool IsDead => throw new System.NotImplementedException();

        public ICharacter Target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public string Team => throw new System.NotImplementedException();

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void Init(CharacterData data, ILevelData level, string name, string team)
        {
            throw new System.NotImplementedException();
        }

        public bool IsHostileTo(ICharacter target)
        {
            throw new System.NotImplementedException();
        }

        public void LookAt(Vector3 target)
        {
            throw new System.NotImplementedException();
        }

        public void MoveForward(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(float damage, ICharacter sender)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ICharacter> Watch()
        {
            throw new System.NotImplementedException();
        }
    }
}