#nullable disable
using System;


public class Resource
{
    public string Type { get; set; }

    private int amount; // Backing field for the Amount property

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

    public Resource(string type, int initialAmount)
    {
        Type = type;
        Amount = initialAmount; // Uses the property, not the field
    }
}
