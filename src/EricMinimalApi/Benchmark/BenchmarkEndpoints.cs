namespace EricDemo.MinimalApi.Simple;

public static class BenchmarkEndpoints
{
	public static void Map(WebApplication app)
	{
		var group = app.MapGroup("/benchmark");
		// BenchmarkEndpoints.Map(group);
		// OtherEndpoints.Map(group);
		// MoreEndpoints.Map(group);
	}
}
