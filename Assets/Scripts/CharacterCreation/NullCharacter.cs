using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class NullCharacter : ICharacter
    {
        public string Name => "";

        public float Health => 0;

        public Vector3 Position => Vector3.zero;

        public Vector3 Waypoint => Vector3.zero;

        public bool IsDead => true;

        public ICharacter Target { get; set; }

        public string Team => "";

        public bool AtDestination => false;

        public bool TargetInRange => false;

        public void Attack()
        {

        }

        public bool IsHostileTo(ICharacter target)
        {
            return false;
        }

        public void LookAt(Vector3 target)
        {

        }

        public void MoveForward(float deltaTime)
        {

        }

        public void TakeDamage(float damage, ICharacter sender)
        {

        }

        IEnumerable<ICharacter> watched = new ICharacter[0];
        public IEnumerable<ICharacter> Watch()
        {
            return watched;
        }

        public void Init(CharacterData data, ILevelData level, string name, string team)
        {

        }

        public void SetDestination(Vector3 destination)
        {

        }
    }
}