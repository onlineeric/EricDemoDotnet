namespace EricDemo.MinimalApi.Simple;

public static class SimpleEndpoints
{
	public static void Map(WebApplication app)
	{
		var group = app.MapGroup("/simple");
		ItemEndpoints.Map(group);
		// OtherEndpoints.Map(group);
		// MoreEndpoints.Map(group);
	}
}
