namespace EricDemo.SharedLibrary.BenchMark;

public class BenchMarkTestResult
{
	public string Id { get; set; }
	public string? Server { get; set; }
	public string? Algorithm { get; set; }
	public bool Parallelization { get; set; }
	public double CpuTime { get; set; }
	public long MemoryUsed { get; set; }
	public long ExecutionTime { get; set; }
	public DateTime FinishedTime { get; set; }

	public BenchMarkTestResult()
	{
		Id = Guid.NewGuid().ToString();
	}
}