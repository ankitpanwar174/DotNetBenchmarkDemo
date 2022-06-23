[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class BenchmarkSort
{
    private int[] arrayNumber;
    private int[] randomOrderedNumbers;

    //400
    [Params(200)]
    public int Length { get; set; }

    [GlobalSetup]
    public void GlobalSetup()
    {
        arrayNumber = Enumerable.Range(0, Length).ToArray();
        randomOrderedNumbers = Randomizer.ShuffleArray(arrayNumber);
    }


    [Benchmark(Baseline = true)]
    public void InsertionSort()
    {
        for (int i = 0; i < randomOrderedNumbers.Length; i++)
        {
            var item = randomOrderedNumbers[i];
            var currentIndex = i;
            while (currentIndex > 0 && randomOrderedNumbers[currentIndex - 1] > item)
            {
                randomOrderedNumbers[currentIndex] = randomOrderedNumbers[currentIndex - 1];
                currentIndex--;
            }
            randomOrderedNumbers[currentIndex] = item;
        }
    }

    [Benchmark]
    public void BubbleSort()
    {
        int temp = 0;
        for (int write = 0; write < randomOrderedNumbers.Length; write++)
        {
            for (int sort = 0; sort < randomOrderedNumbers.Length - 1; sort++)
            {
                if (randomOrderedNumbers[sort] > randomOrderedNumbers[sort + 1])
                {
                    temp = randomOrderedNumbers[sort + 1];
                    randomOrderedNumbers[sort + 1] = randomOrderedNumbers[sort];
                    randomOrderedNumbers[sort] = temp;
                }
            }
        }
    }


    [Benchmark]
    public void BuiltInSortWithComparison()
    {
        Array.Sort(randomOrderedNumbers, (a, b) => b.CompareTo(a));
    }

    [Benchmark]
    public void SortWithLINQ()
    {
        randomOrderedNumbers = randomOrderedNumbers.OrderByDescending(s => s).ToArray();
    }
}

