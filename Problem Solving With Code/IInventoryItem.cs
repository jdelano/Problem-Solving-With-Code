using System;

public interface IInventoryItem
{
    string Name { get; }
    double Weight { get; }
    string GetDescription();
}
