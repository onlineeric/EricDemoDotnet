using System.Security.Cryptography;

namespace EricDemo.SharedLibrary.BenchMark;

public class BenchMarkSha256 : BenchMarkTestCase {
	private byte[] data;
	private SHA256 sha256;
	const int dataLength = 10000000;
	const int randomSeed = 28;

	
	public BenchMarkSha256() : base() {
		data = new byte[dataLength];
		new Random(randomSeed).NextBytes(data);
		sha256 = SHA256.Create();
	}
	public BenchMarkSha256 Run(int loopCount = 1000) {
		StartBenchmarking();
		for (int i = 0; i < loopCount; i++) {
			sha256.ComputeHash(data);
		}
		StopBenchmarking();
		return this;
	}
}