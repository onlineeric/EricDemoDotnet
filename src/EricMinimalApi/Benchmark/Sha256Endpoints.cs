using EricDemo.SharedLibrary.BenchMark;
using Microsoft.AspNetCore.Authorization;

namespace EricDemo.MinimalApi.Benchmark;

public static class Sha256Endpoints
{
	public static void Map(RouteGroupBuilder parentGroup)
	{
		var group = parentGroup.MapGroup("/Sha256");
		group.MapGet("/{exeTimes}", GetSha256);
	}

	[Authorize]
	private static IResult GetSha256(int exeTimes)
	{
		if (exeTimes < 1)
		{
			return TypedResults.BadRequest("exeTimes must be greater than 0");
		}

		if (exeTimes > 1000000)
		{
			return TypedResults.BadRequest("exeTimes must be less than 1,000,000");
		}

		var result = new BenchMarkSha256().Run(exeTimes).Result;
		result!.Server = Constants.ServerName;
		return TypedResults.Ok(result);
	}
}