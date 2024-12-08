#nullable disable
using System;

public class CraftingSystem
{
    private Recipe[] recipes = new Recipe[5]; // Array to store available recipes
    private ResourceType[,] craftingGrid = new ResourceType[3, 3]; // 3x3 crafting grid

    public CraftingSystem()
    {
        ClearGrid();  // Initialize the crafting grid to be empty (None)

        // Example recipe for a steel sword
        recipes[0] = new Recipe("Steel Sword", new ResourceType[,]
        {
            { ResourceType.None, ResourceType.Steel, ResourceType.None },
            { ResourceType.None, ResourceType.Steel, ResourceType.None },
            { ResourceType.None, ResourceType.Wood, ResourceType.None }
        }, new Resource(ResourceType.Sword, 1));

        #region Add more recipes here...
        recipes[1] = new Recipe("Bucket", new ResourceType[,]
        {
            { ResourceType.None, ResourceType.None, ResourceType.None },
            { ResourceType.Steel, ResourceType.None, ResourceType.Steel },
            { ResourceType.None, ResourceType.Steel, ResourceType.None }
        }, new Resource(ResourceType.Bucket, 1));
        #endregion
    }

    // Method to remove all resources from the grid
    private void ClearGrid()
    {
        // Initialize the crafting grid to be empty (None)
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                craftingGrid[i, j] = ResourceType.None;
            }
        }
    }

    // Method to place a resource on the grid
    public void PlaceResource(int row, int col, ResourceType type)
    {
        craftingGrid[row, col] = type;
        Console.WriteLine($"Placed {type} at position ({row}, {col})");
    }

    public void RemoveResource(int row, int column)
    {
        craftingGrid[row, column] = ResourceType.None;
    }

    // Method to attempt crafting
    public Resource Craft()
    {
        foreach (var recipe in recipes)
        {
            if (recipe != null && recipe.Matches(craftingGrid))
            {
                Console.WriteLine($"Crafted {recipe.Name}!");
                return recipe.Result;
            }
        }
        Console.WriteLine("No matching recipe found.");
        return null;
    }

    public void DisplayGrid()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                Console.Write($"[{craftingGrid[row, column]}] ");
            }
            Console.WriteLine();
        }
    }
}
