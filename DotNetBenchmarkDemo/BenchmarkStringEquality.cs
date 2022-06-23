
[MemoryDiagnoser]
[RankColumn]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
public class BenchmarkStringEquality
{
	private string stringA = null;
	private string stringB = null;

	[Params(10, 20)]
	public int StringLength { get; set; }

	[GlobalSetup]
	public void Initialize()
	{
		stringA = Randomizer.GetRandomAsciiString(StringLength);
		stringB = stringA + Randomizer.GetRandomAsciiString(1);
	}

	[Benchmark]
	public bool EqualsOperator()
	{
		return stringA == stringB;
	}

	[Benchmark]
	public bool EqualsMethod()
	{
		return stringA.Equals(stringB);
	}

	[Benchmark]
	public bool EqualsOrdinalCompare()
	{
		return stringA.Equals(stringB, StringComparison.Ordinal);
	}

	[Benchmark]
	public bool EqualsOrdinalIgnoreCase()
	{
		return stringA.Equals(stringB, StringComparison.OrdinalIgnoreCase);
	}

	[Benchmark]
	public bool EqualsInvariantCulture()
	{
		return stringA.Equals(stringB, StringComparison.InvariantCulture);
	}

	[Benchmark]
	public bool EqualsInvariantCultureIgnoreCase()
	{
		return stringA.Equals(stringB, StringComparison.InvariantCultureIgnoreCase);
	}
}

