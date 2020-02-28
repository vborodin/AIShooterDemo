using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public interface ICharacter
    {
        string Name { get; }
        float Health { get; }
        float Power { get; }
        Vector3 Position { get; }
        Vector3 LookVector { get; }
        Vector3 Waypoint { get; }
        Vector3 Destination { get; }
        bool AtDestination { get; }
        bool IsDead { get; }
        ICharacter Target { get; set; }
        bool TargetInRange { get; }
        string Team { get; }
        float AttackRange { get; }

        void MoveForward(float deltaTime);
        void LookAt(Vector3 target);
        void Attack();
        void CastAbility(ICharacter target);
        bool CanCastAbility();
        void TakeDamage(float damage, ICharacter sender);
        IEnumerable<ICharacter> Watch();
        bool IsHostileTo(ICharacter target);
        void SetDestination(Vector3 destination);
        void RestoreDestination();
        void Init(CharacterData data, LevelDataBase level, string team, float difficultyModifier);
    }
}