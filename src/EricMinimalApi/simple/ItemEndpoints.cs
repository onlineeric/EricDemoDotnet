namespace EricDemo.MinimalApi.Simple;

public static class ItemEndpoints
{
	public static void Map(RouteGroupBuilder parentGroup)
	{
		var group = parentGroup.MapGroup("/item");
		group.MapGet("/{id}", GetItem);
		group.MapGet("/allItems", GetItems);
		group.MapPost("/", PostItem);
		group.MapPut("/", PutItem);
		group.MapPatch("/", PatchItem);
		group.MapDelete("/{id}", DeleteItem);
	}

	private static async Task<IResult> GetItem (int id) => await Task.FromResult(Results.Ok(new {result = $"Get method return item {id}"}));
	
	private static async Task<IResult> GetItems() {
		await Task.Delay(100);
		return Results.Ok(new { Result = "Get method return all items" });
	}

	private static async Task<IResult> PostItem(ItemBody item) {
		await Task.Delay(100);
		int id = new Random().Next(1, int.MaxValue);
		ItemBody returnItem = new ItemBody() { Id = id, Name = item.Name, Description = item.Description };
		return Results.Created(
			new Uri($"/simple/item/{id}", UriKind.Relative), 
			new { status = "success", result = returnItem}
		);
	}

	private static async Task<IResult> PutItem(ItemBody item) {
		if (item.Id == 0) {
			return Results.BadRequest(new { status = "error", message = "Item Id is required." });
		}
		await Task.Delay(100);
		return Results.NoContent();  // 204 No Content for a successful PUT, PATCH, or DELETE.
	}

	private static async Task<IResult> PatchItem(ItemBody item) {
		if (item.Id == 0) {
			return Results.BadRequest(new { status = "error", message = "Item Id is required." });
		}
		await Task.Delay(100);
		return Results.NoContent();  // 204 No Content for a successful PUT, PATCH, or DELETE.
	}

	private static async Task<IResult> DeleteItem(string id) {
		if (string.IsNullOrWhiteSpace(id) || id == "0") {
			return Results.BadRequest(new { status = "error", message = "Item Id is invalid." });
		}
		await Task.Delay(100);
		return Results.NoContent();  // 204 No Content for a successful PUT, PATCH, or DELETE.
	}
}

public class ItemBody
{
	public int Id { get; set; }
	public string Name { get; set; } = "";
	public string Description { get; set; } = "";
}
