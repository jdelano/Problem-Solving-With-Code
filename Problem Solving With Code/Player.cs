#nullable disable

public class Player
{
  private List<Item> inventory;
  private int maxInventorySize = 10;

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
    inventory = new List<Item>();
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

  public bool IsInventoryFull
  {
    get
    {
      return inventory.Count >= maxInventorySize;
    }
  }
  // Method to add an item to the player’s inventory
  public bool AddToInventory(Item item)
  {
    if (item.Type == ItemType.None)
    {
      Console.WriteLine("Invalid item: None cannot be added to inventory.");
      return false;
    }

    if (IsInventoryFull)
    {
      Console.WriteLine("Your inventory is full! You cannot add more items.");
      return false;
    }

    var existingItem = inventory.FirstOrDefault(i => i.Type == item.Type);
    if (existingItem != null)
    {
      int addedAmount = item.Amount;
      existingItem.Amount += item.Amount;
      Console.WriteLine($"{addedAmount} {item.Type} added to inventory.");
      Console.WriteLine($"Total: {existingItem.Amount}");
    }
    else
    {
      Item newItem = new Item(item.Type, item.Amount);
      inventory.Add(newItem);
      Console.WriteLine($"{item.Type} has been added to your inventory.");
    }
    return true;
  }


  public bool HasInInventory(Item item)
  {
    return inventory.Any(inv => inv.Type == item.Type && inv.Amount >= item.Amount);
  }

  public bool RemoveFromInventory(Item item)
  {
    for (int index = inventory.Count - 1; index >= 0; index--)
    {
      if (inventory[index].Type == item.Type)
      {
        if (inventory[index].Amount >= item.Amount)
        {
          inventory[index].Amount -= item.Amount;

          // If the amount goes to zero, remove the resource from the inventory
          if (inventory[index].Amount == 0)
          {
            inventory.RemoveAt(index);
          }

          Console.WriteLine($"{item.Amount} {item.Type} removed from your inventory.");
          return true;
        }
        else
        {
          Console.WriteLine($"Not enough {item.Type} to remove.");
          return false;
        }
      }
    }

    Console.WriteLine($"{item.Type} not found in inventory.");
    return false;
  }
  public void DisplayInventory()
  {
    Console.WriteLine("Inventory:");
    // Loop through each item in the inventory array
    for (int index = 0; index < inventory.Count; index++)
    {
      if (inventory[index] != null)
      {
        // Display details of the item if it's not null
        Console.WriteLine($"Slot {index + 1}:");
        inventory[index].DisplayInfo();
      }
    }
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


