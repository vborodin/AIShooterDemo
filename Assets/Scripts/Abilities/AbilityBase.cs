namespace AIShooterDemo
{
    public abstract class AbilityBase
    {
        public abstract void Cast(ICharacter caster, ICharacter target);
        public abstract float Cost { get; }

        public static AbilityBase Create(IAbilityData abilityData)
        {
            if (abilityData == null)
            {
                return new NullAbility();
            }
            AbilityBase ability;

            switch (abilityData.AbilityName)
            {
                case "Mockup":
                    ability = new MockupAbility(abilityData);
                    break;
                default:
                    ability = new NullAbility();
                    break;
            }

            return ability;
        }
    }
}