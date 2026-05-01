using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scarlet.Comet.Data;
using Scarlet.Comet.Domain.Catalog;

namespace Scarlet.Comet.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private readonly StoreContext _context;

    public CatalogController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetItems()
    {
        return Ok(_context.Items.Include(i => i.Ratings).ToList());
    }

    [HttpGet("{id:int}")]
    public ActionResult<Item> GetItem(int id)
    {
        var item = _context.Items
            .Include(i => i.Ratings)
            .FirstOrDefault(x => x.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    [HttpPost]
    public ActionResult<Item> PostItem(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();

        return Ok(item);
    }

    [HttpPost("{id:int}/ratings")]
    public ActionResult PostRating(int id, Rating rating)
    {
        var item = _context.Items
            .Include(i => i.Ratings)
            .FirstOrDefault(x => x.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        item.AddRating(rating);
        _context.SaveChanges();

        return Ok(item);
    }

    [HttpPut("{id:int}")]
    public ActionResult PutItem(int id, Item item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        _context.Entry(item).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

   [HttpDelete("{id:int}")]
[Authorize("delete:catalog")]
public ActionResult DeleteItem(int id)
{
    var item = _context.Items
        .Include(i => i.Ratings)
        .FirstOrDefault(x => x.Id == id);

    if (item == null)
    {
        return NotFound();
    }

    if (item.Ratings.Any())
    {
        _context.RemoveRange(item.Ratings);
    }

    _context.Items.Remove(item);
    _context.SaveChanges();

    return NoContent();
}
}