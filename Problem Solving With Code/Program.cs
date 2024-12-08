#nullable disable
using System;

// Create a variable totalResources and set it to 0.
int totalResources = 0;

// Prompt user for the number of resources collected.
Console.Write("Enter number of resources collected: ");
int collected = int.Parse(Console.ReadLine());

// Add the collected resources to totalResources.
totalResources += collected;

// Print out the totalResources.
Console.WriteLine($"Total Resources: {totalResources}");