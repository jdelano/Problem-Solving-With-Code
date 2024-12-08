#nullable disable
using System;
using System.Text.Json;

public class CraftingSystem
{
    private List<Recipe> recipes = new(); // Array to store available recipes
    private ItemType[][] craftingGrid = new ItemType[3][]; // 3x3 crafting grid
	private string filePath = "recipes.json";

    public CraftingSystem()
    {
        ClearGrid();  // Initialize the crafting grid to be empty (None)
		if (File.Exists(filePath))
		{
			// Load recipes from the JSON file
			string jsonString = File.ReadAllText(filePath);
			recipes = JsonSerializer.Deserialize<List<Recipe>>(jsonString);
		}
		else
		{
			// Define some default recipes
			DefineDefaultRecipes();
			// Save the default recipes to the file
			string jsonString = JsonSerializer.Serialize(recipes);
			File.WriteAllText(filePath, jsonString);
		}
    }

	private void DefineDefaultRecipes()
	{
		recipes.Add(new Recipe("Shield", new ItemType[][]
		{
			new ItemType[] { ItemType.SolidWood, ItemType.SteelPlate, ItemType.SolidWood },
			new ItemType[] { ItemType.SteelPlate, ItemType.SteelPlate, ItemType.SteelPlate },
			new ItemType[] { ItemType.SolidWood, ItemType.SteelPlate, ItemType.SolidWood }
		}, new Equipment(ItemType.Shield, 1, 200, 5)));

		recipes.Add(new Recipe("SteelPlate", new ItemType[][]
		{
			new ItemType[] { ItemType.Steel, ItemType.Steel, ItemType.Steel },
			new ItemType[] { ItemType.Steel, ItemType.Steel, ItemType.Steel },
			new ItemType[] { ItemType.Steel, ItemType.Steel, ItemType.Steel }
		}, new Resource(ItemType.SteelPlate, 1)));

		recipes.Add(new Recipe("SolidWood", new ItemType[][]
		{
			new ItemType[] { ItemType.Wood, ItemType.Wood, ItemType.Wood },
			new ItemType[] { ItemType.Wood, ItemType.Wood, ItemType.Wood },
			new ItemType[] { ItemType.Wood, ItemType.Wood, ItemType.Wood }
		}, new Resource(ItemType.SolidWood, 1)));
	}

    // Method to remove all resources from the grid
    private void ClearGrid()
    {
        // Initialize the crafting grid to be empty (None)
        for (int i = 0; i < 3; i++)
        {
            craftingGrid[i] = new ItemType[3];
            for (int j = 0; j < 3; j++)
            {
                craftingGrid[i][j] = ItemType.None;
            }
        }
    }

    // Method to place a resource on the grid
    public void PlaceResource(int row, int col, ItemType type)
    {
        craftingGrid[row][col] = type;
        Console.WriteLine($"Placed {type} at position ({row}, {col})");
    }

    public void RemoveResource(int row, int column)
    {
        craftingGrid[row][column] = ItemType.None;
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
                Console.Write($"[{craftingGrid[row][column]}] ");
            }
            Console.WriteLine();
        }
    }
}
