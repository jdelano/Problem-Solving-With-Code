using System;

public class Apple : IInventoryItem
{
	public string Name { get; } = "Apple";
	public double Weight { get; } = 0.2;

	public string GetDescription()
	{
		return "A fresh apple that restores energy when eaten.";
	}
}