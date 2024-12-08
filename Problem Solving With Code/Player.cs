#nullable disable
using System;

public class Player
{
  private Resource[] inventory;

  #region Other Player Properties and Fields...
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

  public bool CanLevelUp
  {
    get { return XP >= xpForNextLevel; }
  }

  public bool CanCollectResources
  {
    get { return Stamina >= staminaNeededToCollect; }
  }

  public bool CanRestoreStamina
  {
    get { return XP >= maxStamina - Stamina; }
  }
  public string Name { get; set; }
  public int Score { get; set; }

  #endregion

  public Player(string playerName)
  {
    // Player inventory can store up to 10 resources.
    inventory = new Resource[10];
    #region Other constructor statements...
    Name = playerName;
    Score = 0;
    XP = 0;
    staminaNeededToCollect = 10;
    maxStamina = 100;
    Stamina = 100;
    Level = 1;
    xpForNextLevel = 100;
    #endregion
  }

  public bool AddToInventory(Resource resource)
  {
    bool resourceAdded = false;
    for (int index = 0; index < inventory.Length; index++)
    {
      if (inventory[index] == null)
      {
        inventory[index] = resource;
        resourceAdded = true;
        break;
      }
      else if (inventory[index].Type == resource.Type)
      {
        inventory[index].Amount += resource.Amount;
        resourceAdded = true;
        break;
      }
    }
    return resourceAdded;
  }

  public bool HasInInventory(ResourceType resourceType)
  {
    for (int index = 0; index < inventory.Length; index++)
    {
      if (inventory[index] != null && inventory[index].Type == resourceType)
      {
        return true;
      }
    }
    return false;
  }

  public bool RemoveFromInventory(Resource resource)
  {
    for (int index = 0; index < inventory.Length; index++)
    {
      if (inventory[index] != null && inventory[index].Type == resource.Type)
      {
        if (inventory[index].Amount >= resource.Amount)
        {
          inventory[index].Amount -= resource.Amount;

          // If the amount goes to zero, remove the resource from the inventory
          if (inventory[index].Amount == 0)
          {
            inventory[index] = null;
          }

          Console.WriteLine($"{resource.Amount} {resource.Type} removed from your inventory.");
          return true;
        }
        else
        {
          Console.WriteLine($"Not enough {resource.Type} to remove.");
          return false;
        }
      }
    }

    Console.WriteLine($"{resource.Type} not found in inventory.");
    return false;
  }

  public void DisplayInventory()
  {
    Console.WriteLine("Inventory:");

    // Loop through each item in the inventory array
    for (int index = 0; index < inventory.Length; index++)
    {
      if (inventory[index] != null)
      {
        // Display details of the item if it's not null
        Console.WriteLine($"Slot {index + 1}:");
        Console.WriteLine($" - Type: {inventory[index].Type}");
        Console.WriteLine($" - Amount: {inventory[index].Amount}");
      }
    }

    Console.WriteLine(); // Add a blank line for better readability
  }

  public void CollectResource(Resource resource, Func<int> bonus)
  {
    if (CanCollectResources)
    {
      if (AddToInventory(resource))
      {
        switch (resource.Amount)
        {
          #region Bonus calculation case statements here...

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
            #endregion
        }
        Stamina -= staminaNeededToCollect;
      }
      else
      {
        Console.WriteLine($"Inventory is full!");
      }
    }
    else
    {
      Console.WriteLine("Not enough stamina to collect resources!");
    }
  }

  #region Other Player Methods...
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

  // Method to display the player's current status
  public void DisplayStatus()
  {
    Console.WriteLine($"Player Status:");
    Console.WriteLine($"Level: {Level}");
    Console.WriteLine($"XP: {XP}");
    Console.WriteLine($"Stamina: {Stamina}/{maxStamina}");
    Console.WriteLine($"Score: {Score}");
  }
  
  #endregion

}


