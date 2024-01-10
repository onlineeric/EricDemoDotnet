using System.Security.Cryptography;
using EricDemo.SharedLibrary.BenchMark;

namespace EricDemo.Tests.SharedLibraryTests.BenchMark;

public class BenchMarkMd5Tests 
{
	private BenchMarkMd5 _benchMarkMd5;

	[SetUp]
	public void Setup()
	{
		_benchMarkMd5 = new BenchMarkMd5();
	}

	[Test]
	public void RunTest()
	{
		// Arrange
		int loopCount = 500;

		// Act
		var selfRef = _benchMarkMd5.Run(loopCount);

		// Assert
		Assert.That(selfRef, Is.Not.Null);
		Assert.That(selfRef, Is.InstanceOf<BenchMarkMd5>());
		Assert.That(selfRef.Result, Is.Not.Null);
		Assert.That(selfRef.Result, Is.InstanceOf<BenchMarkTestResult>());
		Assert.That(selfRef.Result.ExecutionTime, Is.GreaterThanOrEqualTo(0));
	}
}