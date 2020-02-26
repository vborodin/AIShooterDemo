using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public class RobotCharacter : MonoBehaviour, ICharacter
    {
        public string Name => "Robot";

        public float Health => 1000;

        public Vector3 Position => gameObject.transform.position;

        public Vector3 Destination => gameObject.transform.position;

        public bool IsDead => false;

        public ICharacter Target { get; set; }

        public string Team => "";

        public bool AtDestination => false;

        public void Attack()
        {

        }

        public void Init(CharacterData data, ILevelData level, string name, string team)
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

        public IEnumerable<ICharacter> Watch()
        {
            return new ICharacter[0];
        }
    }
}