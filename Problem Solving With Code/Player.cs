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
		// Decision logic based on the collected resources
		switch (resource.Amount)
		{
			case >= 100:
				Score += resource.Amount;
				Console.WriteLine("You earned a score bonus!");
				break;
			case >= 50:
				Console.WriteLine("Good job! You're halfway there.");
				break;

			case 0:
				Console.WriteLine("No resources collected.");
				break;
			default:
				Console.WriteLine("Keep going to reach your goal.");
				break;
		}
	}
}
