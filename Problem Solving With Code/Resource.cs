#nullable disable
using System;

public class Resource
{
    public ResourceType Type { get; set; }

    private int amount;
    public int Amount
    {
        get { return amount; }
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Error: Setting amount to 0.");
                amount = 0;
            }
            else
            {
                amount = value;
            }
        }
    }

    public Resource(ResourceType type, int initialAmount)
    {
        Type = type;
        Amount = initialAmount;
    }
}
