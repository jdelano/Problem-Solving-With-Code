#nullable disable
using System;

public class CraftingSystem
{
	private List<Recipe> recipes = new();
	private ItemType[,] craftingGrid = new ItemType[3, 3]; // 3x3 crafting grid

	public CraftingSystem()
	{
		ClearGrid();  // Initialize the crafting grid to be empty (None)

		// Define example recipes
		recipes.Add(new Recipe("Steel Plate", new ItemType[,]
		{
						{ ItemType.Steel, ItemType.Steel, ItemType.Steel },
						{ ItemType.Steel, ItemType.Steel, ItemType.Steel },
						{ ItemType.Steel, ItemType.Steel, ItemType.Steel }
		}, new Resource(ItemType.SteelPlate, 1)));

		recipes.Add(new Recipe("Solid Wood", new ItemType[,]
		{
						{ ItemType.Wood, ItemType.Wood, ItemType.Wood },
						{ ItemType.Wood, ItemType.Wood, ItemType.Wood },
						{ ItemType.Wood, ItemType.Wood, ItemType.Wood }
		}, new Resource(ItemType.SolidWood, 1)));

		recipes.Add(new Recipe("Bucket", new ItemType[,]
		{
						{ ItemType.None, ItemType.SteelPlate, ItemType.None },
						{ ItemType.SteelPlate, ItemType.SteelPlate, ItemType.SteelPlate },
						{ ItemType.None, ItemType.SteelPlate, ItemType.None }
		}, new Resource(ItemType.Bucket, 1)));

		recipes.Add(new Recipe("Shield", new ItemType[,]
		{
						{ ItemType.SolidWood, ItemType.SteelPlate, ItemType.SolidWood },
						{ ItemType.SteelPlate, ItemType.SteelPlate, ItemType.SteelPlate },
						{ ItemType.SolidWood, ItemType.SteelPlate, ItemType.SolidWood }
		}, new Equipment(ItemType.Shield, 1, 200, 5)));
	}

	public bool CraftItem(Player player, ItemType itemType)
	{
		Recipe recipe = recipes.FirstOrDefault(r => r.Result.Type == itemType);
		if (recipe == null)
		{
			Console.WriteLine($"Recipe for {itemType} not found.");
			return false;
		}

		List<Item> requiredItems = recipe.GetRequiredItems();

		// Base case: If player has all items needed, craft the item
		if (requiredItems.All(req => player.HasInInventory(req)))
		{
			foreach (Item req in requiredItems)
			{
				player.RemoveFromInventory(req);
			}
			player.AddToInventory(recipe.Result);
			Console.WriteLine($"Successfully crafted: {itemType}");
			return true;
		}

		// Recursive case: Craft the components first
		foreach (Item req in requiredItems)
		{
			while (!player.HasInInventory(req))
			{
				Console.WriteLine($"Need to craft {req.Type} for {itemType}");
				if (!CraftItem(player, req.Type))
				{
					Console.WriteLine($"Cannot craft {req.Type}. Missing resources.");
					return false;
				}
			}
		}

		// After crafting necessary components, craft the main item
		return CraftItem(player, itemType);
	}

	#region Other Crafting System Methods Here...

	// Method to remove all resources from the grid
	public void ClearGrid()
	{
		for (int row = 0; row < 3; row++)
		{
			for (int column = 0; column < 3; column++)
			{
				craftingGrid[row, column] = ItemType.None;
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
		craftingGrid[row, column] = ItemType.None;
	}

	// Method to attempt crafting
	public Item Craft()
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

	#endregion
}

