namespace EricDemo.SharedLibrary.BenchMark;

using System;
using System.Diagnostics;

public class BenchMarkTestCase
{
	protected Process process;
	protected Stopwatch stopwatch;
	private TimeSpan startCpuTime;
	private long startMemory;
	public BenchMarkTestResult? Result { get; set; }
	
	public BenchMarkTestCase()
	{
		process = Process.GetCurrentProcess();
		stopwatch = new Stopwatch();
	}
	protected void StartBenchmarking() {
		startCpuTime = process.TotalProcessorTime;
		GC.Collect();
		startMemory = GC.GetTotalMemory(forceFullCollection: false);
		stopwatch.Start();
	}
	protected void StopBenchmarking() {
		stopwatch.Stop();
		var endCpuTime = process.TotalProcessorTime;
		var endMemory = GC.GetTotalMemory(forceFullCollection: false);

		Result = new BenchMarkTestResult {
			CpuTime = (endCpuTime - startCpuTime).TotalMilliseconds,
			MemoryUsed = endMemory - startMemory,
			ExecutionTime = stopwatch.ElapsedMilliseconds,
			FinishedTime = DateTime.Now
		};
	}
}