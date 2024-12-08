using System;

public class Equipment : Item, IInventoryItem
{
	// Additional properties unique to Equipment
	public int Durability { get; set; }
	public int AttackPower { get; set; }

    public string Name { get; set; }

    public double Weight { get; set; }

    // Constructor for Equipment, which calls the base constructor
    public Equipment(ItemType type, int amount, int durability, int attackPower) : base(type, amount)
	{
		Durability = durability;
		AttackPower = attackPower;
		Name = type.ToString();
	}

	// Method to display equipment-specific information
	public override void DisplayInfo()
	{
		base.DisplayInfo();
		Console.WriteLine($"Durability: {Durability}");
		Console.WriteLine($"Attack Power: {AttackPower}");
	}

    public string GetDescription()
    {
        return $"{Name} weighing {Weight} with attack {AttackPower} and durability {Durability}";
    }
}

