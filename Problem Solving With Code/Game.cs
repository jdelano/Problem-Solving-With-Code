#nullable disable
#pragma warning disable IDE0066


public class Game
{
    public Player Player { get; set; }
    private CraftingSystem craftingSystem;

    #region Other Game fields here...
    private static Random random = new();
    private bool shouldContinue;
    private int maxAttempts;
    #endregion
    public Game(int maxAttempts, string playerName)
    {
        this.maxAttempts = maxAttempts;
        shouldContinue = true;
        Player = new(playerName);
        craftingSystem = new CraftingSystem();
    }


    private int DisplayMenu(string[] options)
    {
        int choice;
        do
        {
            Console.WriteLine("Choose an action: ");
            for (int index = 0; index < options.Length; index++)
            {
                Console.WriteLine($"{index + 1}. {options[index]}");
            }
            string input = Console.ReadLine();
            bool isValid = int.TryParse(input, out choice);
            if (!isValid || choice < 1 || choice > options.Length)
            {
                Console.WriteLine($"Please enter a number between 1 and {options.Length}.");
            }
        } while (choice < 1 || choice > options.Length);
        return choice;
    }


public void PlayTurn()
{
    // Show player's status before each action
    Player.DisplayStatus();

    string[] options = { "Collect Resources", "Restore Stamina", "Level Up", "Show Inventory", "Craft", "Quit" };
    int choice = DisplayMenu(options);
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
            Player.DisplayInventory();
            break;
        case 5:
            Craft();
            break;
        case 6:
            Console.WriteLine("Thanks for playing!");
            shouldContinue = false;
            break;
    }
}

    public void Craft()
    {
        Console.WriteLine("Entering crafting mode...");
        bool crafting = true;

        while (crafting)
        {
            Player.DisplayInventory();
            Console.WriteLine("Crafting Grid:");
            craftingSystem.DisplayGrid();
            string[] options = { "Place a resource on the grid", "Remove a resource from the grid", "Attempt to craft", "Cancel crafting" };
            int choice = DisplayMenu(options);
            switch (choice)
            {
                case 1:
                    PlaceResourceOnGrid();
                    break;
                case 2:
                    RemoveResourceFromGrid();
                    break;
                case 3:
                    var craftedItem = craftingSystem.Craft();
                    if (craftedItem != null)
                    {
                        // TODO: Player.AddToInventory(craftedItem);
                        Console.WriteLine($"Successfully crafted: {craftedItem.Type}");
                        crafting = false; // Exit crafting loop after successful crafting
                    }
                    else
                    {
                        Console.WriteLine("No matching recipe found. Try again.");
                    }
                    break;
                case 4:
                    Console.WriteLine("Exiting crafting mode.");
                    crafting = false;
                    break;
            }
        }
    }


    // Helper method to place a resource on the crafting grid
    private void PlaceResourceOnGrid()
    {
        string[] rows = { "Top Row", "Middle Row", "Bottom Row" };
        int row = DisplayMenu(rows) - 1;

        string[] columns = { "Left Column", "Middle Column", "Right Column" };
        int column = DisplayMenu(columns) - 1;

        string[] resources = Enum.GetNames(typeof(ItemType));
        int resourceIndex = DisplayMenu(resources) - 1;
        ItemType ItemType = (ItemType)resourceIndex;
        // if (Player.HasInInventory(ItemType))
        // {
        //     craftingSystem.PlaceResource(row, column, ItemType);
        //     Console.WriteLine($"{ItemType} placed at ({row}, {column}).");
        //     Player.RemoveFromInventory(new Resource(ItemType, 1)); // Remove one unit of the resource from inventory
        // }
        // else
        // {
        //     Console.WriteLine($"There is no {ItemType} in your inventory.");
        // }
    }

    // Helper method to remove a resource from the crafting grid
    private void RemoveResourceFromGrid()
    {
        string[] rows = { "Top Row", "Middle Row", "Bottom Row" };
        int row = DisplayMenu(rows) - 1;

        string[] columns = { "Left Column", "Middle Column", "Right Column" };
        int column = DisplayMenu(columns) - 1;

        craftingSystem.RemoveResource(row, column);
    }

    #region Other Game methods here...



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
            // int maxIndex = Enum.GetValues(typeof(ItemType)).Length;
            int resourceIndex = random.Next(1, 7);
            ItemType selectedResource = (ItemType)resourceIndex;

            // Collect resources of the randomly selected type
            Resource resource = new(selectedResource, turnTotal);
            // Player.CollectResource(resource, () =>
            // {
            //     switch (selectedResource)
            //     {
            //         case ItemType.Gold:
            //             return 2;
            //         case ItemType.Gemstone:
            //             return 3;
            //         default:
            //             return 1;
            //     }
            // });
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

    #endregion

}


