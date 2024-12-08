// Player player = new Player("Alex");

// Resource wood = new Resource(ItemType.Wood, 10);
// Resource moreWood = new Resource(ItemType.Wood, 15);
// Resource stone = new Resource(ItemType.Stone, 5);

// player.CollectResource(wood, () => { return 1; });
// player.CollectResource(moreWood, () => { return 1; });
// player.CollectResource(stone, () => { return 1; });

// Equipment sword = new Equipment(ItemType.Sword, 1, 50, 25);
// player.AddToInventory(sword);

// Equipment sword = new Equipment(ItemType.Sword, 1, 50, 25);
// player.AddToInventory(sword);

// Resource wood = new Resource(ItemType.Wood, 10);
// player.CollectResource(wood, () => { return 1; });

// player.DisplayInventory();

Game game = new(3, "Alex");
game.Run();