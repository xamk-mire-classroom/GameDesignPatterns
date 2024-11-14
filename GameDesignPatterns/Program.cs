static class Program
{
    static void Main(string[] args)
    {
        DemonstrateGameSystem();
    }

    static void DemonstrateGameSystem()
    {
        // Singleton usage
        GameDesignPatterns.Patterns.Singleton.GameWorld gameWorld = GameDesignPatterns.Patterns.Singleton.GameWorld.getInstance();
        // ...
    }
}