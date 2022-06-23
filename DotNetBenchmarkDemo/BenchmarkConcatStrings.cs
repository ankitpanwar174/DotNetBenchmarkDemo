[MemoryDiagnoser]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class BenchmarkConcatStrings
{
	int NumberOfItems = 1000;

	[Benchmark]
	public string PlusOperator()
	{
		var str = "";
		for (int i = 0; i < NumberOfItems; i++)
		{
			str += "Demo Test" + i;
		}
		return str;
	}

	[Benchmark]
	public string ConcatStringsUsingString()
	{
		var str = "";
		for (int i = 0; i < NumberOfItems; i++)
		{
			str.Concat("Demo Test" + i);
		}
		return str;
	}	

	[Benchmark(Baseline = true)]
	public string ConcatStringsUsingStringBuilder()
	{
		var sb = new StringBuilder();
		for (int i = 0; i < NumberOfItems; i++)
		{
			sb.Append("Demo Test" + i);
		}
		return sb.ToString();
	}

	[Benchmark]
	public string ConcatStringsUsingGenericList()
	{
		var list = new List<string>(NumberOfItems);
		for (int i = 0; i < NumberOfItems; i++)
		{
			list.Add("Demo Test" + i);
		}
		return list.ToString();
	}

}