namespace AIShooterDemo
{
    public class NullAbility : AbilityBase
    {
        public override float Cost => float.MaxValue;

        public override void Cast(ICharacter caster, ICharacter target)
        {

        }
    }
}