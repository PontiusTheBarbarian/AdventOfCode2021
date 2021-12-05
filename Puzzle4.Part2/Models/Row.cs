public class Row
{
	public Row(int[] numbers)
	{
		Cells = new List<Cell>();
		foreach (var number in numbers)
		{
			Cells.Add(new Cell(number));
		}
	}

	public List<Cell> Cells { get; }
}
