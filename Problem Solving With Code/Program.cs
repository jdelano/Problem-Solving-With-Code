// Player player = new("Alex");

// // Simulate collecting 10 units of wood
// Resource wood = new(ResourceType.Wood, 10);
// player.CollectResource(wood, () => { return 1; });

// // Simulate collecting 5 units of steel
// Resource steel = new(ResourceType.Steel, 5);
// player.CollectResource(steel, () => { return 1; });

// // Simulate collecting another 15 units of wood
// Resource moreWood = new(ResourceType.Wood, 15);
// player.CollectResource(moreWood, () => { return 1; });

// player.DisplayInventory();

Game game = new(3, "Alex");
game.Run();