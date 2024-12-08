#nullable disable
using System;

public class Player
{
	private List<IInventoryItem> inventory;

	#region Other Player Properties and Fields...
	private int xp;
	private int stamina;
	private int level;
	private int xpForNextLevel;
	private int staminaNeededToCollect;
	private int maxStamina;

	public int XP
	{
		get { return xp; }
		set { xp = value < 0 ? 0 : value; }
	}

	public int Stamina
	{
		get { return stamina; }
		set { stamina = value < 0 ? 0 : value > maxStamina ? maxStamina : value; }
	}

	public int Level
	{
		get { return level; }
		set { level = value < 0 ? 0 : value; }
	}

	public bool CanLevelUp
	{
		get { return XP >= xpForNextLevel; }
	}

	public bool CanCollectResources
	{
		get { return Stamina >= staminaNeededToCollect; }
	}

	public bool CanRestoreStamina
	{
		get { return XP >= maxStamina - Stamina; }
	}
	public string Name { get; set; }
	public int Score { get; set; }

	#endregion

	public Player(string playerName)
	{
		// Player inventory can store up to 10 resources.
		inventory = new();
		#region Other constructor statements...
		Name = playerName;
		Score = 0;
		XP = 0;
		staminaNeededToCollect = 10;
		maxStamina = 100;
		Stamina = 100;
		Level = 1;
		xpForNextLevel = 100;
		#endregion
	}

	private int maxInventorySize = 10;

	public bool IsInventoryFull
	{
		get
		{
			return inventory.Count >= maxInventorySize;
		}
	}

	public bool AddToInventory(IInventoryItem item)
	{
		if (inventory.Count >= maxInventorySize)
		{
			Console.WriteLine("Your inventory is full! Cannot add more items.");
			return false;
		}
		inventory.Add(item);
		Console.WriteLine($"{item.Name} has been added to your inventory.");
		return true;
	}



	// Displaying the inventory
	public void DisplayInventory()
	{
		Console.WriteLine("Inventory:");
		foreach (var item in inventory)
		{
			Console.WriteLine($"- {item.Name}: {item.GetDescription()} (Weight: {item.Weight})");
		}
	}


	#region Other Player Methods...
	public void LevelUp()
	{
		if (CanLevelUp)
		{
			Level++;
			XP -= xpForNextLevel;
			maxStamina += 10;
			Console.WriteLine("You Leveled Up! Max stamina increased.");
		}
		else
		{
			Console.WriteLine("You don't have enough XP to level up.");
		}
	}

	public void RestoreStamina()
	{
		if (CanRestoreStamina)
		{
			int costToRestore = maxStamina - Stamina;
			XP -= costToRestore;
			Stamina = maxStamina;
			Console.WriteLine($"Stamina restored! {costToRestore} XP used.");
		}
		else
		{
			Console.WriteLine("Not enough XP to restore stamina!");
		}
	}

	// Method to display the player's current status
	public void DisplayStatus()
	{
		Console.WriteLine($"Player Status:");
		Console.WriteLine($"Level: {Level}");
		Console.WriteLine($"XP: {XP}");
		Console.WriteLine($"Stamina: {Stamina}/{maxStamina}");
		Console.WriteLine($"Score: {Score}");
	}

	#endregion

}


