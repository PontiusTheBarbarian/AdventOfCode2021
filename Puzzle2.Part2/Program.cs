using Puzzle2.Part2;

var puzzle = new Puzzle();
var result = puzzle.Calculate();

Console.WriteLine($"Horizontal Postion: {result.horizontalPos}, Depth: {result.depth}");
Console.WriteLine($"Answer: {result.horizontalPos * result.depth}");
Console.ReadLine();
//2039912