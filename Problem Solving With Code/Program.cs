// Set up the game parameters
int sims = 10000;
// Number of resource collection attempts per turn
int maxAttempts = 3;
// To track how many times the player's score increases
int increases = 0;
// Instantiate Game with maxAttempts and a sample player name
Game game = new(maxAttempts, "TestPlayer");

// Run the simulation
for (int i = 0; i < sims; i++)
{
    // Store the player's score before the turn
    int initialScore = game.Player.Score;
    // Simulate a turn
    game.PlayTurn();
    // Check if the player's score increased after this turn
    if (game.Player.Score > initialScore)
    {
        increases++;
    }
}
// Display percentage of turns player's score increased
double increasePercent = (double)increases / sims * 100.0;
Console.WriteLine($"After {sims} simulations:");
Console.WriteLine($"The score increased {increases} times.");
Console.WriteLine($"This is {increasePercent}% of the turns.");
