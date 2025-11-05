using System;

// The contract for our "Bot"
public interface IInputReader
{
    // The event that fires on every new line of input
    event Action<string> OnInputReceived;

    // A method to start the bot
    void StartListening();
}
