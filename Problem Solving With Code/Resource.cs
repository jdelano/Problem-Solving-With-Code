#nullable disable
using System;

public class Resource : Item, IInventoryItem
{
    public string HarvestLocation { get; set; }

    public string Name { get; set; }

    public double Weight { get; set; }

    // Constructor for Resource, which calls the base constructor
    public Resource(ItemType type, int amount) : base(type, amount)
    {
        switch (type)
        {
            case ItemType.Wood:
                HarvestLocation = "Forest";
                break;
            case ItemType.Stone:
                HarvestLocation = "Ground";
                break;
            case ItemType.Steel:
            case ItemType.Graphite:
            case ItemType.Gold:
            case ItemType.Gemstone:
                HarvestLocation = "Mine";
                break;
            default:
                HarvestLocation = "Unknown";
                break;
        }
    }

    // Method to display resource-specific information
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Harvest Location: { HarvestLocation}");
    }

    public string GetDescription()
    {
        return $"{Name} weighing {Weight} with harvest location {HarvestLocation}";
    }
}
