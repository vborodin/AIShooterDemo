namespace AIShooterDemo
{
    public interface ICharacterPreset
    {
        string CharacterData { get; }
        string BehaviourType { get; }
        string BehaviourTemplate { get; }
    }
}