namespace AIShooterDemo
{
    public class MockupLevelProviderFactory : ILevelProviderFactory
    {
        public ILevelProvider GetLevelProvider()
        {
            return new MockupLevelProvider("MockupLevelProvider");
        }
    }
}