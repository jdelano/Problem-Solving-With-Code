#nullable disable
using System;

// Create a player object using the constructor
Player player1 = new("Alex");

// Creating a resource object using the constructor
Resource wood = new("Wood", 5);

// Player collects the resource
player1.CollectResource(wood);
