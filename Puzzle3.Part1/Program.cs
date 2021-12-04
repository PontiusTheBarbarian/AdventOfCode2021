using Puzzle3.Part1;

var puzzle = new Puzzle();
var result = puzzle.Calculate();

Console.WriteLine($"Gamma rate: {result.gammaRate}, Epsilon rate: {result.epsilionRate}");
Console.WriteLine($"Power consumption: {result.gammaRate * result.epsilionRate}");
Console.ReadLine();
//1092896