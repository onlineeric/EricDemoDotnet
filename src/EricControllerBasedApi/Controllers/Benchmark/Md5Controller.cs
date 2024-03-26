using EricDemo.SharedLibrary.BenchMark;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EricDemo.EricControllerBasedApi.Controllers;

[ApiController]
[Route("benchmark/[controller]")]
[Authorize]
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
		var Result = new BenchMarkMd5().Run(execTimes).Result;
		Result!.Server = Constants.ServerName;
		return Result;
	}



}