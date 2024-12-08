// Create a player object
Player player1 = new("Alex"); 

// Test Case 1: resource.Amount = -5 
Resource negativeResources = new("Stone", -5); 
player1.CollectResource(negativeResources);
Console.WriteLine($"Player Score: {player1.Score}\n"); 
// Expected Output: "Error: Count cannot be negative." 
// Expected Score: 0 (no change) 

// Test Case 2: resource.Amount = 0 
Resource zeroResources = new("Wood", 0); 
player1.CollectResource(zeroResources); 
Console.WriteLine($"Player Score: {player1.Score}\n");  
// Expected Output: "No resources collected." 
// Expected Score: 0 (no change) 

// Test Case 3: resource.Amount = 50 
Resource fiftyResources = new("Iron", 50); 
player1.CollectResource(fiftyResources); 
Console.WriteLine($"Player Score: {player1.Score}\n");   
// Expected Output: "Good job! You're halfway there." 
// Expected Score: 0 (no change) 

// Test Case 4: resource.Amount = 99
Resource ninetyNineResources = new("Gold", 99); 
player1.CollectResource(ninetyNineResources); 
Console.WriteLine($"Player Score: {player1.Score}\n");   
// Expected Output: "Good job! You're halfway there." 
// Expected Score: 0 (no change) 

// Test Case 5: resource.Amount = 100 Resource 
Resource hundredResources = new("Diamond", 100); 
player1.CollectResource(hundredResources);  
Console.WriteLine($"Player Score: {player1.Score}\n");  
// Expected Output: "You earned a score bonus!"
// Expected Score: 100 (score updated)
