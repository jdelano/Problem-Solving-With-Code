#nullable disable
using System;

public class Game
{
    private static Random random = new();
    private bool shouldContinue;
    private int maxAttempts;
    public Player Player { get; set; }

    public Game(int maxAttempts, string playerName)
    {
        this.maxAttempts = maxAttempts;
        shouldContinue = true;
        Player = new(playerName);
    }

    public void PlayTurn()
    {
        int turnTotal = 0;
        for (int i = 0; i < maxAttempts; i++)
        {
            int attemptTotal = random.Next(20, 51);
            turnTotal += attemptTotal;
            Console.Write($"Attempt {i + 1}/{maxAttempts}: ");
            Console.WriteLine($"{attemptTotal} resources.");
        }
        // Randomly select a resource type
        int maxIndex = Enum.GetValues(typeof(ResourceType)).Length;
        int resourceIndex = random.Next(maxIndex);
        ResourceType selectedResource = (ResourceType)resourceIndex;

        // Collect resources of the randomly selected type
        Resource resource = new(selectedResource, turnTotal);
        Player.CollectResource(resource);
        Console.WriteLine($"Collected this turn: {turnTotal}");
        Console.WriteLine($"Your score: {Player.Score}");
        Console.WriteLine($"You collected: {resource.Type}");
    }

    public void Run()
    {
        do
        {
            Console.WriteLine("Starting a new turn...");

            // Call the method to handle a single turn
            PlayTurn();

            // Ask the player if they want to continue playing
            Console.Write("Want to play another turn (y/n)? ");
            string input = Console.ReadLine();

            // Update the flag based on the player's input
            if (input.ToLower() != "y")
            {
                shouldContinue = false;
                Console.WriteLine("Thank you for playing!");
            }
        } while (shouldContinue);
    }
}

