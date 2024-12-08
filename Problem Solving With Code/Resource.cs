#nullable disable
using System;

public class Resource
{
    public string Type { get; set; }
    public int Amount { get; set; }

    // Resource constructor	
    public Resource(string type, int amount)
    {
        Type = type;
        Amount = amount;
    }
}
