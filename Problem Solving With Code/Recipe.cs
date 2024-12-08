using System;

public class Recipe
{
    public string Name { get; set; }
    private ItemType[,] pattern;
    public Item Result { get; private set; }

    public Recipe(string name, ItemType[,] pattern, Item result)
    {
        Name = name;
        this.pattern = pattern;
        Result = result;
    }

    // Method to check if the current grid matches the recipe pattern
    public bool Matches(ItemType[,] grid)
    {
        for (int row = 0; row < 3; row++)
        {
            for (int column = 0; column < 3; column++)
            {
                if (grid[row, column] != pattern[row, column])
                {
                    return false;  // If any cell doesn't match, the recipe fails
                }
            }
        }
        return true;  // If all cells match, the recipe is valid
    }


	public List<Item> GetRequiredItems()
	{
		List<Item> requiredItems = new();
		for (int row = 0; row < 3; row++)
		{
			for (int column = 0; column < 3; column++)
			{
				ItemType currentType = pattern[row, column];
				if (currentType != ItemType.None)
				{
					var existingItem = requiredItems
						.FirstOrDefault(item => item.Type == currentType);
					if (existingItem != null)
					{
						existingItem.Amount++;
					}
					else
					{
						requiredItems.Add(new Item(currentType, 1));
					}
				}
			}
		}
		return requiredItems;
	}
}



