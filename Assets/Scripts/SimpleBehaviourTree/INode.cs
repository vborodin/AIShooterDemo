namespace AIShooterDemo
{
    public interface INode
    {
        string Name { get; }
        void Init(ICharacter agent);
        NodeState Process(float timeDelta, ICharacter agent);
    }
}