using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AIShooterDemo
{
    public class TeamCharacter : MonoBehaviour, ICharacter
    {
        ICharacter Leader
        {
            get
            {
                if (team == null || team.Count == 0)
                {
                    return new NullCharacter();
                }
                return team.First();
            }
        }
        ICollection<ICharacter> team;

        public string Name => Leader.Name;
        public float Health
        {
            get
            {
                return team.Sum((x) => x.Health);
            }
        }
        public float Power => 0f;
        public Vector3 Position => Leader.Position;
        public Vector3 LookVector => Vector3.zero;
        public Vector3 Waypoint => Vector3.zero;
        public bool AtDestination => false;
        public bool IsDead
        {
            get
            {
                return team.Aggregate(true, (val, current) => { return val && current.IsDead; });
            }
        }
        public ICharacter Target { get; set; }
        public bool TargetInRange => false;
        public string Team => Leader.Team;
        public float AttackRange => 0;
        public Vector3 Destination => Leader.Destination;
        public void Attack()
        {

        }
        public void Init(CharacterData data, LevelDataBase level, string team, float difficultyModifier)
        {

        }
        public void Init(ICollection<ICharacter> team)
        {
            this.team = team;
        }
        public bool IsHostileTo(ICharacter target)
        {
            return Leader.IsHostileTo(target);
        }
        public void LookAt(Vector3 target)
        {

        }
        public void MoveForward(float deltaTime)
        {

        }
        public void RestoreDestination()
        {

        }
        public void SetDestination(Vector3 destination)
        {

        }
        public void TakeDamage(float damage, ICharacter sender)
        {

        }
        public IEnumerable<ICharacter> Watch()
        {
            return new ICharacter[0];
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