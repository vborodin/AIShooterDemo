using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AIShooterDemo
{
    public class TeamCharacter : ICharacter
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

        public TeamCharacter(ICollection<ICharacter> team)
        {
            this.team = team;
        }

        public string Name => Leader.Name;
        public float Health
        {
            get
            {
                return team.Sum((x) => x.Health);
            }
        }
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
        public void Init(CharacterData data, LevelDataBase level, string team)
        {

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
    }
}