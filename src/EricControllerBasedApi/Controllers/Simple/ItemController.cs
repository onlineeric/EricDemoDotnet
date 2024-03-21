using System.Security.Cryptography;
using EricDemo.EricControllerBasedApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EricDemo.EricControllerBasedApi.Controllers;

[ApiController]
[Route("simple/[controller]")]
[Authorize]
public class ItemController : ControllerBase
{
	private readonly ILogger<ItemController> _logger;

	public ItemController(ILogger<ItemController> logger)
	{
		_logger = logger;
	}

	// get simple/item/{id} return item with id
	[HttpGet("{id}", Name = "GetItemById")]
	public Item Get(int id)
	{
		return new Item
		{
			Id = id,
			Name = $"Item {id}",
			Date = DateOnly.FromDateTime(DateTime.Now)
		};
	}

	// get simple/item/allItems return all items
	[HttpGet("allItems")]
	public IEnumerable<Item> GetAll()
	{
		return Enumerable.Range(1, 5).Select(index => new Item
		{
			Id = index,
			Name = $"Item {index}",
			Date = DateOnly.FromDateTime(DateTime.Now)
		})
		.ToArray();
	}

	// get simple/item/GetItemByName?name=Item 1
	[HttpGet("GetItemByName")]
	public Item GetItemByName(string name)
	{
		return new Item
		{
			Id = RandomNumberGenerator.GetInt32(1, int.MaxValue),
			Name = name,
			Date = DateOnly.FromDateTime(DateTime.Now)
		};
	}

	// post simple/item
	[HttpPost]
	public IActionResult Post(Item item)
	{
		int newId = RandomNumberGenerator.GetInt32(1, int.MaxValue);
		item.Id = newId;
		return CreatedAtRoute("GetItemById", new { id = newId }, item);
	}

	// put simple/item
	[HttpPut]
	public IActionResult Put(Item item)
	{
		return Ok(item);
	}

	// patch simple/item
	[HttpPatch]
	public IActionResult Patch(Item item)
	{
		return Ok(item);
	}

	// delete simple/item/{id}
	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
	{
		return Ok(new Item {
			Id = id,
			Name = $"Item {id}",
			Date = DateOnly.FromDateTime(DateTime.Now)
		});
	}
}
