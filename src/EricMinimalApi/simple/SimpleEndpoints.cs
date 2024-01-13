namespace EricDemo.MinimalApi.Simple;

public static class SimpleEndpoints
{
	public static void Map(WebApplication app)
	{
		var group = app.MapGroup("/simple");
		group.MapGet("/item/{id}", GetItem);
		group.MapGet("/items", GetItems);
		//group.MapPost("/item", PostItem);

	}

	private static async Task<IResult> GetItem (int id) => await Task.FromResult(Results.Ok(new {result = $"Get method return item {id}"}));
	
	private static async Task<IResult> GetItems() {
		await Task.Delay(100);
		return Results.Ok(new { Result = "Get method return all items" });
	}

	//private static string PostItem()

}
