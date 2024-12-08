using System;

public class Equipment : Item
{
	// Additional properties unique to Equipment
	public int Durability { get; set; }
	public int AttackPower { get; set; }

	// Constructor for Equipment, which calls the base constructor
	public Equipment(ItemType type, int amount, int durability, int attackPower) 
        : base(type, amount)
	{
		Durability = durability;
		AttackPower = attackPower;
	}

	// Method to display equipment-specific information
	public override void DisplayInfo()
	{
		base.DisplayInfo();
		Console.WriteLine($"Durability: {Durability}");
		Console.WriteLine($"Attack Power: {AttackPower}");
	}
}

