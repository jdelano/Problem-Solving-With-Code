using System;

namespace Problem_Solving_With_Code;

public class Sword : IInventoryItem
{
	public string Name { get; } = "Sword";
	public double Weight { get; } = 10.0;

	public string GetDescription()
	{
		return "A sharp blade, useful for close combat.";
	}
}
