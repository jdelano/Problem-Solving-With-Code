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

    // Method to display the menu and get player's choice
    public int DisplayMenu()
    {
        int choice;
        do
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Collect Resources");
            Console.WriteLine("2. Restore Stamina");
            Console.WriteLine("3. Level Up");
            Console.WriteLine("4. Quit");
            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out choice);

            if (!isValid || choice < 1 || choice > 4)
            {
                Console.WriteLine("Please enter a number between 1 and 4.");
            }
        } while (choice < 1 || choice > 4);
        return choice;
    }


    public void PlayTurn()
    {
        // Show player's status before each action
        Player.DisplayStatus();
        // Display the menu and get the player's choice
        int choice = DisplayMenu();
        switch (choice)
        {
            case 1:
                CollectResources();
                break;
            case 2:
                Player.RestoreStamina();
                break;
            case 3:
                Player.LevelUp();
                break;
            case 4:
                Console.WriteLine("Thanks for playing!");
                shouldContinue = false;
                break;
        }
    }

    public void CollectResources()
    {
        if (Player.CanCollectResources)
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
            Player.CollectResource(resource, () =>
            {
                switch (selectedResource)
                {
                    case ResourceType.Gold:
                        return 2;
                    case ResourceType.Gemstone:
                        return 3;
                    default:
                        return 1;
                }
            });
            Console.WriteLine($"Collected this turn: {turnTotal}");
            Console.WriteLine($"Your score: {Player.Score}");
            Console.WriteLine($"You collected: {resource.Type}");
        }
        else
        {
            Console.WriteLine("Insufficient Stamina to Collect Resources!");
        }

    }

    public void Run()
    {
        do
        {
            Console.WriteLine("Starting a new turn...");
            // Call the method to handle a single turn
            PlayTurn();
        } while (shouldContinue);
    }
}

