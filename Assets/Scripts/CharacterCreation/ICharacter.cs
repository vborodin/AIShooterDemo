using System.Collections.Generic;
using UnityEngine;

namespace AIShooterDemo
{
    public interface ICharacter
    {
        string Name { get; }
        float Health { get; }
        Vector3 Position { get; }
        Vector3 Destination { get; }
        bool AtDestination { get; }
        bool IsDead { get; }
        ICharacter Target { get; set; }
        string Team { get; }

        void MoveForward(float deltaTime);
        void LookAt(Vector3 target);
        void Attack();
        void TakeDamage(float damage, ICharacter sender);
        IEnumerable<ICharacter> Watch();
        bool IsHostileTo(ICharacter target);

        void Init(CharacterData data, ILevelData level, string name, string team);
    }
}