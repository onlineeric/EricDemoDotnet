using EricDemo.SharedLibrary.BenchMark;
using System.Security.Cryptography;

namespace SharedLibraryTests;

public class BenchMarkSha256Tests
{
	private BenchMarkSha256 _benchMarkSha256;

	[SetUp]
	public void Setup()
	{
		_benchMarkSha256 = new BenchMarkSha256();
	}

	[Test]
	public void RunTest()
	{
		// Arrange
		int loopCount = 500;

		// Act
		var selfRef = _benchMarkSha256.Run(loopCount);

		// Assert
		Assert.That(selfRef, Is.Not.Null);
		Assert.That(selfRef, Is.InstanceOf<BenchMarkSha256>());
		Assert.That(selfRef.Result, Is.Not.Null);
		Assert.That(selfRef.Result, Is.InstanceOf<BenchMarkTestResult>());
		Assert.That(selfRef.Result.ExecutionTime, Is.GreaterThanOrEqualTo(0));
	}
}
