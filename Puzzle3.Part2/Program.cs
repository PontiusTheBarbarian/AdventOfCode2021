using Puzzle3.Part1;

var puzzle = new Puzzle();
var result = puzzle.Calculate();

Console.WriteLine($"Oxygen rating: {result.oxygenRating}, CO2 rating: {result.co2Rating}");
Console.WriteLine($"Life support rating: {result.oxygenRating * result.co2Rating}");
Console.ReadLine();