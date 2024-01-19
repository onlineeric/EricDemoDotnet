using EricDemo.MinimalApi.Benchmark;

namespace EricDemo.MinimalApi.Simple;

public static class BenchmarkEndpoints
{
	public static void Map(WebApplication app)
	{
		var group = app.MapGroup("/benchmark");
		Sha256Endpoints.Map(group);
		Md5Endpoints.Map(group);
		
		// OtherEndpoints.Map(group);
		// MoreEndpoints.Map(group);
	}
}
