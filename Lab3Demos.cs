using System;
using System.Collections.Generic;

public class Lab3Demos
{
    public static void Main()
    {
        RunDemos();
    }

    public static void RunDemos()
    {
        //ScopeDemo();
        //RefDemo();
        //OutDemo();
        //InDemo();
    }

#region Scope

    public static void ScopeDemo()
    {
        Console.WriteLine("--- DEMO 1: SCOPE ---");
        // Method-level scope
        string methodVar = "I live in the method.";
        Console.WriteLine(methodVar);

        if (true)
        {
            // Block-level scope
            string blockVar = "I only live inside this 'if' block.";
            Console.WriteLine(blockVar);
        }
        // The line below would cause a compiler error because blockVar is out of scope.
        // Console.WriteLine(blockVar); 
    }
    
#endregion

#region Ref

    // A simple class for demonstration
    public class Player
    {
        public string Name { get; set; }
    }

    public static void RefDemo()
    {
        Console.WriteLine("\n--- DEMO 2: REF VS DEFAULT ---");
        int health = 100;
        Player player = new Player { Name = "Link" };
        Console.WriteLine($"Before: Health is {health}, Player is {player.Name}");
        DefaultBehavior(health, player);
        Console.WriteLine($"After Default: Health is {health}, Player is {player.Name}"); // Health is unchanged, Name is changed
        RefBehavior(ref health);
        Console.WriteLine($"After Ref: Health is {health}"); // Health is changed

    }

    public static void DefaultBehavior(int val, Player p)
    {
        val = 0; // Modifies the COPY
        p.Name = "Zelda"; // Modifies the ORIGINAL object through the reference
        Console.WriteLine($"Inside Default: val is {val}, player is {p.Name}");
    }

    public static void RefBehavior(ref int val)
    {
        val = 0; // Modifies the ORIGINAL variable
        Console.WriteLine($"Inside Ref: val is {val}");
    }

#endregion

#region Out

    public static void OutDemo()
    {
        Console.WriteLine("\n--- DEMO 3: OUT PATTERN ---");
        string input = "123";
        if (TryConvertString(input, out int result))
        {
            Console.WriteLine($"Successfully converted '{input}' to {result}");
        }
    }

    public static bool TryConvertString(string text, out int value)
    {
        // We MUST assign something to 'value' before the method exits.
        try
        {
            value = int.Parse(text);
            return true;
        }
        catch (FormatException)
        {
            value = 0; // Assign a default value on failure
            return false;
        }
    }
    
#endregion

#region In

    // A large struct to show the 'in' modifier's value
    public struct GameState
    {
        public long Score;
        public long Ticks;
        // Imagine 50 more fields here...
    }

    public static void InDemo()
    {
        Console.WriteLine("\n--- DEMO 4: IN GUARANTEE ---");
        GameState currentState = new GameState { Score = 9001, Ticks = 123456789 };
        DisplayState(in currentState);
        // The line below would cause a compiler error:
        // AttemptToModifyState(in currentState); 
        Console.WriteLine("Successfully displayed state without modification.");
    }

    public static void DisplayState(in GameState state)
    {
        // We can read 'state' just fine.
        Console.WriteLine($"Displaying state: Score = {state.Score}");
        // But if we uncomment the line below, we get a compiler error.
        // state.Score = 0; // ERROR: Cannot modify 'in' parameter
    }

#endregion

}
