using System.Reflection.Metadata.Ecma335;

namespace EricDemo.MinimalApi.Simple;

public static class SimpleEndpoints
{
	public static void Map(WebApplication app)
	{
		var group = app.MapGroup("/simple");
		group.MapGet("/item/{id}", GetItem);
		group.MapGet("/items", GetItems);
		group.MapPost("/item", PostItem);

	}

	private static async Task<IResult> GetItem (int id) => await Task.FromResult(Results.Ok(new {result = $"Get method return item {id}"}));
	
	private static async Task<IResult> GetItems() {
		await Task.Delay(100);
		return Results.Ok(new { Result = "Get method return all items" });
	}

	private static async Task<IResult> PostItem(ItemBody item) {
		await Task.Delay(100);
		return Results.Created(
			new Uri("/simple/item/1", UriKind.Relative), 
			new { Results = $"Post method return item {item.Name} - {item.Description}"}
		);
	}
}

public class ItemBody
{
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
}
