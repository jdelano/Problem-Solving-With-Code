#nullable disable
using System;

public class Player
{
	public string Name { get; set; }
	public int Score { get; set; }

	// Player constructor
	public Player(string playerName)
	{
 		Name = playerName;
		Score = 0;
	}	
    
	// Method for the player to collect a resource
	public void CollectResource(Resource resource)
	{
		Score += resource.Amount;
		Console.WriteLine($"{Name} collected {resource.Amount} units of	{resource.Type}.");
	}
}
