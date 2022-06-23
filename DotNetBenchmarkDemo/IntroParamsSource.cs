
// Ex of ParamsSource
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class IntroParamsSource
{

	[ParamsSource(nameof(ValuesForA))]
	public int A { get; set; }


	[ParamsSource(nameof(ValuesForB))]
	public int B;


	public IEnumerable<int> ValuesForA => new[] { 50, 100,1999 };


	public static IEnumerable<int> ValuesForB() => new[] { 5, 10 };

	[Benchmark]
	public void Benchmark()
	{
		var test = A + B;
		Math.Pow(test, 2);
	}
}

//public class IntroArguments
//{
//	[Params(true, false)]
//	public bool AddExtra5Milliseconds;

//	[Benchmark]
//	[Arguments(100, 10)]
//	[Arguments(100, 20)]
//	[Arguments(200, 10)]
//	[Arguments(200, 20)]
//	public void Benchmark(int a, int b)
//	{
//		if (AddExtra5Milliseconds)
//			Thread.Sleep(a + b + 5);
//		else
//			Thread.Sleep(a + b);
//	}
//}

