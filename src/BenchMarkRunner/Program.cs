using System;
using EricDemo.SharedLibrary.BenchMark;

namespace EricDemo.BenchMarkRunner;

public class BenchmarkExample
{
	public static void Main()
	{
		var result = new BenchMarkSha256().Run(500).Result;

		if (result != null) {
			Console.WriteLine($"SHA256 CPU Time: {result.CpuTime} ms");
			Console.WriteLine($"SHA256 Memory Used: {result.MemoryUsed} bytes");
			Console.WriteLine($"SHA256 Execution Time: {result.ExecutionTime} ms");
		} else {
			Console.WriteLine("SHA256 failed");
		}

		result = new BenchMarkMd5().Run(500).Result;

		if (result != null) {
			Console.WriteLine($"MD5 CPU Time: {result.CpuTime} ms");
			Console.WriteLine($"MD5 Memory Used: {result.MemoryUsed} bytes");
			Console.WriteLine($"MD5 Execution Time: {result.ExecutionTime} ms");
		} else {
			Console.WriteLine("MD5 failed");
		}

	}
}
