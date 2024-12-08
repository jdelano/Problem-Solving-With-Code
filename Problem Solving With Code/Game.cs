#nullable disable
using System;

public class Game
{
    // Properties and Fields

    // Relationship property that stores the player
    public Player Player { get; set; }

    // Flag to determine if the game should continue
    private bool shouldContinue;

    // Number of resource collection attempts per turn
    private int maxAttempts;

    // Constructor
    public Game(int maxAttempts, string playerName)
    {
        this.maxAttempts = maxAttempts;
        shouldContinue = true;

        // Instantiate the Player object
        Player = new(playerName);
    }

    // Method to handle resource collection for a single turn
    /// <summary>
    /// Code Block 4.9: Refined PlayTurn Method
    /// </summary>
    public void PlayTurn()
    {
        int turnTotal = 0;
        for (int i = 0; i < maxAttempts; i++)
        {
            int attemptTotal = 0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.Write($"Attempt {i + 1}/{maxAttempts}: ");
                Console.Write("Enter number of resources collected: ");
                string input = Console.ReadLine();

                // Try to parse the input
                isValidInput = int.TryParse(input, out attemptTotal);
                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            turnTotal += attemptTotal;
        }
        // Collect resources and add to the player's total
        Resource resource = new("Wood", turnTotal);
        Player.CollectResource(resource);
        Console.WriteLine($"Collected this turn: {turnTotal}");
        Console.WriteLine($"Your score: {Player.Score}");
    }

    // Main game loop method
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

