#nullable disable
using System;

public class Player
{
	private int xp;
	private int stamina;
	private int level;
	private int xpForNextLevel;
	private int staminaNeededToCollect;
	private int maxStamina;

	public int XP
	{
		get { return xp; }
		set { xp = value < 0 ? 0 : value; }
	}

	public int Stamina
	{
		get { return stamina; }
		set { stamina = value < 0 ? 0 : value > maxStamina ? maxStamina : value; }
	}

	public int Level
	{
		get { return level; }
		set { level = value < 0 ? 0 : value; }
	}

	public Player(string playerName)
	{
		Name = playerName;
		Score = 0;
		XP = 0;
		staminaNeededToCollect = 10;
		maxStamina = 100;
		Stamina = 100;
		Level = 1;
		xpForNextLevel = 100;
	}
	// Method to display the player's current status
	public void DisplayStatus()
	{
		Console.WriteLine($"Player Status:");
		Console.WriteLine($"Level: {Level}");
		Console.WriteLine($"XP: {XP}");
		Console.WriteLine($"Stamina: {Stamina}/{maxStamina}");
		Console.WriteLine($"Score: {Score}");
	}


	public string Name { get; set; }
	public int Score { get; set; }


	public bool CanLevelUp
	{
		get { return XP >= xpForNextLevel; }
	}

	public void LevelUp()
	{
		if (CanLevelUp)
		{
			Level++;
			XP -= xpForNextLevel;
			maxStamina += 10;
			Console.WriteLine("You Leveled Up! Max stamina increased.");
		}
		else
		{
			Console.WriteLine("You don't have enough XP to level up.");
		}
	}

	public bool CanCollectResources
	{
		get { return Stamina >= staminaNeededToCollect; }
	}

	public void CollectResource(Resource resource, Func<int> bonus)
	{
		if (CanCollectResources)
		{
			// Decision logic based on the collected resources
			switch (resource.Amount)
			{
				case >= 100:
					int bonusPoints = resource.Amount * bonus();
					Score += bonusPoints;
					XP += bonusPoints / 5;
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
			Stamina -= staminaNeededToCollect;
		}
		else
		{
			Console.WriteLine("Not enough stamina to collect resources!");
		}
	}

	public bool CanRestoreStamina
	{
		get { return XP >= maxStamina - Stamina; }
	}

	public void RestoreStamina()
	{
		if (CanRestoreStamina)
		{
			int costToRestore = maxStamina - Stamina;
			XP -= costToRestore;
			Stamina = maxStamina;
			Console.WriteLine($"Stamina restored! {costToRestore} XP used.");
		}
		else
		{
			Console.WriteLine("Not enough XP to restore stamina!");
		}
	}

}


