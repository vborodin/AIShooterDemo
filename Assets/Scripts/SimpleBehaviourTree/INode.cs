namespace AIShooterDemo
{
    public interface INode
    {
        void Init(ICharacter context);
        NodeState Process(float timeDelta, ICharacter context);
    }
}