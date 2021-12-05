public class Cell
{
	public Cell(int value)
	{
		Value = value;
	}

	public int Value { get; }
	public bool IsMarked { get; private set; }

	public void Mark()
	{
		IsMarked = true;
	}
}
