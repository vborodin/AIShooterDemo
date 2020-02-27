using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.AI;
using System.Collections;

namespace AIShooterDemo
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(NavMeshAgent))]
    public class ZombieCharacter : MonoBehaviour, ICharacter
    {
        public string Name { get; private set; }
        public float Health { get; private set; }
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
                if (delta.magnitude > agent.height)
                {
                    return false;
                }
                delta.y = 0;
                if (delta.magnitude > agent.radius)
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
                if (Target == null || !IsVisible(Target))
                {
                    return false;
                }
                return (Position - Target.Position).magnitude < data.AttackDistance;
            }
        }

        public float AttackRange => data.AttackDistance;

        public Vector3 LookVector => transform.forward;

        Animator animator;
        NavMeshAgent agent;
        CharacterData data;
        LevelDataBase levelData;

        bool isAttacking = false;
        private IEnumerator AttackCoroutine(float rate)
        {
            isAttacking = true;
            float attackTime = 1f / rate;
            yield return new WaitForSeconds(attackTime);
            isAttacking = false;
            animator.SetBool("attack", false);
        }
        public void Attack()
        {
            //need autotargeting for manual control
            if (Target != null && (Position - Target.Position).magnitude < data.AttackDistance && !isAttacking)
            {
                animator.SetBool("attack", true);
                animator.SetBool("move", false);
                Target.TakeDamage(data.Damage, this);
                StartCoroutine(AttackCoroutine(data.AttackRate));
            }
        }

        public void Init(CharacterData data, LevelDataBase level, string name, string team)
        {
            Health = data.Health;
            Name = name;
            Team = team;
            this.data = data;
            levelData = level;

            animator = GetComponent<Animator>();
            animator.speed = data.Speed;
            agent = GetComponent<NavMeshAgent>();
            agent.destination = levelData.Destination;
            agent.updatePosition = false;
            agent.isStopped = true;
        }

        public bool IsHostileTo(ICharacter target)
        {
            if (target.IsDead || Team.Equals(target.Team))
            {
                return false;
            }
            return true;
        }

        public void LookAt(Vector3 target)
        {
            Vector3 direction = target - transform.position;
            direction.y = 0;
            if (direction.magnitude > agent.radius)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction.normalized), Time.deltaTime * 5f);
            }
        }

        void OnAnimatorMove()
        {
            Vector3 position = animator.rootPosition;
            position.y = agent.nextPosition.y;
            transform.position = position;
            Vector3 worldDeltaPosition = agent.nextPosition - transform.position;
            if (worldDeltaPosition.magnitude > agent.radius)
                agent.nextPosition = transform.position + 0.9f * worldDeltaPosition;
        }

        public void MoveForward(float deltaTime)
        {
            agent.Move(transform.forward * data.Speed * deltaTime);
            animator.SetBool("move", true);
            animator.SetBool("attack", false);
        }

        public void TakeDamage(float damage, ICharacter sender)
        {
            Health -= damage;
            Debug.Log($"{Name} takes damage from {sender.Name}, {Health}/{data.Health} left!");
            if (IsDead)
            {
                Debug.Log($"{Name} is dead!");
                animator.SetBool("dead", true);
            }
        }

        #region sight methods
        private HashSet<ICharacter> inSightRange = new HashSet<ICharacter>();
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
        private bool IsVisible(ICharacter other)
        {
            Vector3 origin = Position;
            Vector3 direction = other.Position - origin;
            origin.y += 1.5f;
            direction.y = 0;
            RaycastHit hitInfo;
            float distance = direction.magnitude + 1;
            if (Physics.Raycast(origin, direction, out hitInfo, distance))
            {
                ICharacter hit = hitInfo.transform.gameObject.GetComponent<ICharacter>();
                if (other.Equals(hit))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        public IEnumerable<ICharacter> Watch()
        {
            return inSightRange.Where(x => !x.IsDead &&
                                            (
                                                (x.Position - this.Position).magnitude < data.FullFOVDistance ||
                                                (
                                                    Vector3.Angle(x.Position - this.Position, transform.forward) < data.FOV &&
                                                    IsVisible(x)
                                                )
                                            )
                                        );
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
    }
}