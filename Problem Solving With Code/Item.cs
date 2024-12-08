using System;
public class Item
{
	// Common properties for all items
	public ItemType Type { get; set; }
	private int amount;
	public int Amount 
	{ 
		get 
		{ 
			return amount; 
		}
		set 
		{ 
			amount = value >= 0 ? value : 0; 
		}
	}

	// Constructor for Item class
	public Item(ItemType type, int amount)
	{
		Type = type;
		Amount = amount;
	}

	// Method to display item information
	public virtual void DisplayInfo()
	{
		Console.WriteLine($"Type: {Type}");
		Console.WriteLine($"Amount: {Amount}");
	}
}