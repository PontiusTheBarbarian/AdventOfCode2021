internal class Puzzle
{
	public List<int> Input = new List<int>() { 4, 3, 4, 5, 2, 1, 1, 5, 5, 3, 3, 1, 5, 1, 4, 2, 2, 3, 1, 5, 1, 4, 1, 2, 3, 4, 1, 4, 1, 5, 2, 1, 1, 3, 3, 5, 1, 1, 1, 1, 4, 5, 1, 2, 1, 2, 1, 1, 1, 5, 3, 3, 1, 1, 1, 1, 2, 4, 2, 1, 2, 3, 2, 5, 3, 5, 3, 1, 5, 4, 5, 4, 4, 4, 1, 1, 2, 1, 3, 1, 1, 4, 2, 1, 2, 1, 2, 5, 4, 2, 4, 2, 2, 4, 2, 2, 5, 1, 2, 1, 2, 1, 4, 4, 4, 3, 2, 1, 2, 4, 3, 5, 1, 1, 3, 4, 2, 3, 3, 5, 3, 1, 4, 1, 1, 1, 1, 2, 3, 2, 1, 1, 5, 5, 1, 5, 2, 1, 4, 4, 4, 3, 2, 2, 1, 2, 1, 5, 1, 4, 4, 1, 1, 4, 1, 4, 2, 4, 3, 1, 4, 1, 4, 2, 1, 5, 1, 1, 1, 3, 2, 4, 1, 1, 4, 1, 4, 3, 1, 5, 3, 3, 3, 4, 1, 1, 3, 1, 3, 4, 1, 4, 5, 1, 4, 1, 2, 2, 1, 3, 3, 5, 3, 2, 5, 1, 1, 5, 1, 5, 1, 4, 4, 3, 1, 5, 5, 2, 2, 4, 1, 1, 2, 1, 2, 1, 4, 3, 5, 5, 2, 3, 4, 1, 4, 2, 4, 4, 1, 4, 1, 1, 4, 2, 4, 1, 2, 1, 1, 1, 1, 1, 1, 3, 1, 3, 3, 1, 1, 1, 1, 3, 2, 3, 5, 4, 2, 4, 3, 1, 5, 3, 1, 1, 1, 2, 1, 4, 4, 5, 1, 5, 1, 1, 1, 2, 2, 4, 1, 4, 5, 2, 4, 5, 2, 2, 2, 5, 4, 4 };

	public int Calculate()
	{
		var lanternFish = Input.Select(i => new LanternFish(false, i)).ToList();

		return CreationCycle(lanternFish, 0).Count();
	}

	public List<LanternFish> CreationCycle(List<LanternFish> fish, int day)
	{
		var nextGeneration = new List<LanternFish>();
		foreach (var (parent, child) in Fish(fish))
		{
			if (child != null)
			{
				nextGeneration.Add(child);
			}
			nextGeneration.Add(parent);
		}

		day++;
		return day == 80 ? nextGeneration : CreationCycle(nextGeneration, day);
	}

	private IEnumerable<(LanternFish parent, LanternFish? child)> Fish(IEnumerable<LanternFish> lanternFish)
	{
		foreach (var fish in lanternFish)
		{
			fish.DecrementAge();
			yield return fish.IsReadyToSpawnOffspring ? (fish, fish.SpawnOffspring()) : (fish, default);
		}
	}

	public class LanternFish
	{
		public LanternFish(bool isNew = true,
			int internalTime = 6)
		{
			IsNew = isNew;
			InternalTimer = isNew ? BirthCycleRate : internalTime;
		}

		private bool IsNew { get; set; }

		private int BirthCycleRate => IsNew ? 8 : 6;

		public bool IsReadyToSpawnOffspring => BirthCycleRate == InternalTimer;

		public int InternalTimer { get; set; }

		public LanternFish SpawnOffspring() => new LanternFish();

		public void DecrementAge()
		{
			if (InternalTimer == 0)
			{
				IsNew = false;
				InternalTimer = BirthCycleRate;
				return;
			}
			InternalTimer--;
		}
	}
}
