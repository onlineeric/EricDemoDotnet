using EricDemo.SharedLibrary.BenchMark;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EricDemo.EricControllerBasedApi.Controllers;

[ApiController]
[Route("benchmark/[controller]")]
[Authorize]
public class Sha256Controller : ControllerBase
{
	private readonly ILogger<ItemController> _logger;

	public Sha256Controller(ILogger<ItemController> logger)
	{
		_logger = logger;
	}

	[HttpGet("{execTimes}", Name = "GetSha256Result")]
	public BenchMarkTestResult? Get(int execTimes)
	{
		var result = new BenchMarkSha256().Run(execTimes).Result;
		result!.Server = Constants.ServerName;
		return result;
	}



}