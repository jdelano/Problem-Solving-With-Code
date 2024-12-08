#nullable disable
using System;

public class CraftingSystem
{
    private Recipe[] recipes = new Recipe[5]; // Array to store available recipes
    private ItemType?[,] craftingGrid = new ItemType?[3, 3]; // 3x3 crafting grid

    public CraftingSystem()
    {
        ClearGrid();  // Initialize the crafting grid to be empty (None)

        // Example recipe for a steel sword
        recipes[0] = new Recipe("Steel Sword", new ItemType?[,]
        {
            { null, ItemType.Steel, null },
            { null, ItemType.Steel, null },
            { null, ItemType.Wood, null }
        }, new Resource(ItemType.Sword, 1));

        #region Add more recipes here...
        recipes[1] = new Recipe("Bucket", new ItemType?[,]
        {
            { null, null, null },
            { ItemType.Steel, null, ItemType.Steel },
            { null, ItemType.Steel, null }
        }, new Resource(ItemType.Bucket, 1));
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
                craftingGrid[i, j] = null;
            }
        }
    }

    // Method to place a resource on the grid
    public void PlaceResource(int row, int col, ItemType type)
    {
        craftingGrid[row, col] = type;
        Console.WriteLine($"Placed {type} at position ({row}, {col})");
    }

    public void RemoveResource(int row, int column)
    {
        craftingGrid[row, column] = null;
    }

    // Method to attempt crafting
    // Method to attempt crafting
    public Item Craft()
    {
        foreach (var recipe in recipes)
        {
            if (recipe != null && recipe.Matches(craftingGrid))
            {
                Console.WriteLine($"Crafted { recipe.Name}!");
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
