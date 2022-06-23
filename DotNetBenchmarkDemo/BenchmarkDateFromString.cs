
 [HtmlExporter]
//[CsvExporter]
//[JsonExporterAttribute.BriefCompressed]

 [MemoryDiagnoser]
//[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net48)]
//[SimpleJob(BenchmarkDotNet.Jobs.RuntimeMoniker.Net60)]
[Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
[RankColumn]
public class BenchmarkDateFromString
{
	string date = "2022-05-23";
	[Benchmark(Baseline = true)]  // 2 sec
	public int GetYearFromSplit()
	{
		var array = date.Split('-');
		return int.Parse(array[0]);
	}

	[Benchmark]
	public int GetYearFromSubstring() //3 
	{
		var index = date.IndexOf('-');
		return int.Parse(date.Substring(0, index));

	}

	[Benchmark]
	public int GetYearFromSpan() // 1 
	{
		ReadOnlySpan<char> dateSpan = date;
		var index = dateSpan.IndexOf('-');
		return int.Parse(dateSpan.Slice(0, index));
	}

}

