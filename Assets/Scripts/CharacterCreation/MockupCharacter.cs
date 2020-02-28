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
        public float Power { get; private set; }
        public Vector3 Position => transform.position;
        public Vector3 Waypoint => agent.steeringTarget;
        public bool IsDead => Health <= 0;
        public ICharacter Target { get; set; }
        public string Team { get; private set; }

        public bool AtDestination
        {
            get
            {
                Vector3 delta = this.Position - agent.destination;
                if (delta.y > agent.height)
                {
                    return false;
                }
                delta.y = 0;
                if (delta.magnitude > agent.radius * 2f)
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

        public float AttackRange => data.AttackDistance;

        public Vector3 LookVector => transform.forward;

        public Vector3 Destination => agent.destination;

        private LevelDataBase levelData;
        private CharacterData data;

        private NavMeshAgent agent;

        public void Init(CharacterData data, LevelDataBase levelData, string team)
        {
            Health = data.Health;
            this.levelData = levelData;
            Team = team;
            this.data = data;
            Name = data.Name;

            agent = GetComponent<NavMeshAgent>();
            agent.destination = levelData.Destination;
            agent.updatePosition = true;
            agent.isStopped = true;
        }

        public void MoveForward(float deltaTime)
        {
            agent.Move(transform.forward * data.Speed * deltaTime);
        }

        public void LookAt(Vector3 target)
        {
            Vector3 direction = target - transform.position;
            if (direction.magnitude > agent.radius)
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
                this.Target.TakeDamage(data.RandomizedDamage, this);
                Power += data.PowerPerHit;
            }
        }

        public void TakeDamage(float damage, ICharacter sender)
        {
            Debug.Log($"{Name} takes damage from {sender.Name}, {Health}/{data.Health} left!");
            Health -= damage;
            Power += data.PowerPerHit;
            if (IsDead)
            {
                Debug.Log($"{Name} is dead!");
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
            agent.destination = destination;
        }

        public void RestoreDestination()
        {
            if (agent.destination != levelData.Destination)
            {
                agent.destination = levelData.Destination;
            }
        }

        public void CastAbility(ICharacter target)
        {

        }

        public bool CanCastAbility()
        {
            return false;
        }
    }
}