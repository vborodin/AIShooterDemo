namespace AIShooterDemo
{
    public class NullAbility : AbilityBase
    {
        public override float Cost => 0f;

        public override void Cast(ICharacter caster, ICharacter target)
        {

        }
    }
}