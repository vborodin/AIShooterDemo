using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace AIShooterDemo
{
    [RequireComponent(typeof(NavMeshAgent))]
    [Serializable]
    public class MockupCharacter : MonoBehaviour, ICharacter
    {
        public string Name { get; private set; }
        public float Health { get; private set; }
        public Vector3 Position => transform.position;
        public Vector3 Waypoint => navMeshAgent.steeringTarget;
        public bool IsDead => Health <= 0;
        public ICharacter Target { get; set; }
        public string Team { get; private set; }

        public bool AtDestination
        {
            get
            {
                Vector3 delta = this.Position - levelData.Destination;
                if (delta.magnitude > navMeshAgent.height)
                {
                    return false;
                }
                delta.y = 0;
                if (delta.magnitude > navMeshAgent.radius)
                {
                    return false;
                }
                return true;
            }
        }

        public bool TargetInRange
        {
            get
            {
                if (Target == null)
                {
                    return false;
                }
                return (Position - Target.Position).magnitude < data.AttackDistance;
            }
        }

        private ILevelData levelData;
        private CharacterData data;

        private NavMeshAgent navMeshAgent;

        public void Init(CharacterData data, ILevelData levelData, string name, string team)
        {
            Health = data.Health;
            this.levelData = levelData;
            this.Team = team;
            this.data = data;
            Name = name;

            navMeshAgent = GetComponent<NavMeshAgent>();
            navMeshAgent.destination = levelData.Destination;
            navMeshAgent.updatePosition = true;
            navMeshAgent.isStopped = true;
        }

        public void MoveForward(float deltaTime)
        {
            navMeshAgent.Move(transform.forward * data.Speed * deltaTime);
        }

        public void LookAt(Vector3 target)
        {
            Vector3 direction = target - transform.position;
            if (direction.magnitude > navMeshAgent.radius)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), Time.deltaTime * 30f);
            }
        }

        public void Attack()
        {
            //or it can spawn bullets
            if (Target != null && (Position - Target.Position).magnitude < data.AttackDistance)
            {
                Debug.Log($"{this.Name} attacks {this.Target.Name} telepathically!");
                this.Target.TakeDamage(data.Damage, this);
            }
        }

        public void TakeDamage(float damage, ICharacter sender)
        {
            Debug.Log($"{this.Name} takes damage from {sender.Name}, {this.Health}/{data.Health} left!");
            this.Health -= damage;
            if (this.IsDead)
            {
                Debug.Log($"{this.Name} is dead!");
                Destroy(gameObject);
            }
        }

        #region sight methods
        private List<ICharacter> inSightRange = new List<ICharacter>();
        private void OnTriggerEnter(Collider other)
        {
            ICharacter character = other.gameObject.GetComponent<ICharacter>();
            if (character != null)
            {
                inSightRange.Add(character);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            ICharacter character = other.gameObject.GetComponent<ICharacter>();
            if (character != null)
            {
                inSightRange.Remove(character);
            }
        }
        #endregion

        public IEnumerable<ICharacter> Watch()
        {
            //raycast logic
            return inSightRange.Where(x => !x.IsDead && Vector3.Angle(x.Position - this.Position, transform.forward) < 60);
        }

        public bool IsHostileTo(ICharacter target)
        {
            //mockup logic with hostile crates
            if (this.Team.Equals(target.Team) || target.IsDead)
            {
                return false;
            }
            return true;
        }

        public void SetDestination(Vector3 destination)
        {
            navMeshAgent.destination = destination;
        }
    }
}