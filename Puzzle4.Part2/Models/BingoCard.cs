internal class BingoCard
{
	public bool IsComplete = false;
	public int LastNumberCalled = 0;
	public List<Row> Rows = new List<Row>();
	public List<Column> Columns = new List<Column>();

	public void CreateRow(int[] numbers)
	{
		Rows.Add(new Row(numbers));
	}

	public void CreateColumns()
	{
		for (var n = 0; n < 5; n++)
		{
			var column = new Column();
			for (var r = 0; r < Rows.Count; r++)
			{
				var cell = Rows[r].Cells[n];
				column.AddCell(cell.Value);
			}
			Columns.Add(column);
		}
	}

	public void Check(int number)
	{
		MarkMatchingNumbers(number, Rows.SelectMany(c => c.Cells).ToList());
		if (IsComplete)
		{
			return;
		}
		MarkMatchingNumbers(number, Columns.SelectMany(c => c.Cells).ToList());
	}

	private void MarkMatchingNumbers(int number, List<Cell> cells)
	{
		foreach (var cell in cells)
		{
			LastNumberCalled = number;
			if (number == cell.Value)
			{
				cell.Mark();
				CheckForWinningRows();
				CheckForWinningColumns();
				if (IsComplete)
				{
					break;
				}
			}
		}
	}

	private void CheckForWinningColumns()
	{
		foreach (var col in Columns)
		{
			IsComplete = col.Cells.All(x => x.IsMarked);
			if (IsComplete)
			{
				break;
			}
		}
	}

	private void CheckForWinningRows()
	{
		foreach (var row in Rows)
		{
			IsComplete = row.Cells.All(x => x.IsMarked);
			if (IsComplete)
			{
				break;
			}
		}
	}
}