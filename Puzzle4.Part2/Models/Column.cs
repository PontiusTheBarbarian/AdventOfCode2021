internal class Column
{
	public Column()
	{
		Cells = new List<Cell>();
	}

	public List<Cell> Cells { get; }

	public void AddCell(int number)
	{
		Cells.Add(new Cell(number));
	}
}

