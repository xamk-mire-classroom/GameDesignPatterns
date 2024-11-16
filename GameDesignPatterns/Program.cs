﻿using GameDesignPatterns.Patterns;

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

        // Create a CharacterFactory
        GameDesignPatterns.Patterns.Factory.CharacterFactory characterFactory = new GameDesignPatterns.Patterns.Factory.CharacterFactory();

        // Create characters dynamically based on type input
        var warrior = characterFactory.CreateCharacter("warrior", "Conan");
        var mage = characterFactory.CreateCharacter("mage", "Gandalf");
        var archer = characterFactory.CreateCharacter("archer", "Legolas");

        // Demonstrate character abilities
        Console.WriteLine(warrior.UseAbility());  
        Console.WriteLine(mage.UseAbility());     
        Console.WriteLine(archer.UseAbility());  

        
    }

}