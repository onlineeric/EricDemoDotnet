using EricDemo.SharedLibrary.BenchMark;
using Microsoft.AspNetCore.Mvc;

namespace EricDemo.EricControllerBasedApi.Controllers;

[ApiController]
[Route("benchmark/[controller]")]
public class Md5Controller : ControllerBase
{
	private readonly ILogger<ItemController> _logger;

	public Md5Controller(ILogger<ItemController> logger)
	{
		_logger = logger;
	}

	[HttpGet("{execTimes}", Name = "GetMd5Result")]
	public BenchMarkTestResult? Get(int execTimes)
	{
		return new BenchMarkMd5().Run(execTimes).Result;
	}



}