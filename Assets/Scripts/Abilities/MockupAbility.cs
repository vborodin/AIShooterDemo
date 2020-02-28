using UnityEngine;

namespace AIShooterDemo
{
    public class MockupAbility : AbilityBase
    {
        private IAbilityData data = null;

        public override float Cost => data.Cost;

        public override void Cast(ICharacter caster, ICharacter target)
        {
            if (caster.Power >= data.Cost)
            {
                GameObject.Instantiate(data.View, target.Position + new Vector3(0, 2.5f, 0), Quaternion.identity);
                target.TakeDamage(data.Damage, caster);
                Debug.Log($"{caster.Name} casts {data.View.name} on {target.Name}!");
            }
        }

        public MockupAbility(IAbilityData abilityData)
        {
            data = abilityData;
        }
    }
}