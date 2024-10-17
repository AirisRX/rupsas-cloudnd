using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MyWebApp.Models
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SampleController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /sample
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }

        // POST: /sample
        [HttpPost]
        public async Task<IActionResult> CreateItem([FromBody] string itemName)
        {
            var item = new Item { Name = itemName };
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItems), new { id = item.Id }, item);
        }

        // PUT: /sample/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] string itemName)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            item.Name = itemName;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: /sample/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null) return NotFound();
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // GET: /sample/operations
        [HttpGet("operations")]
        public IActionResult GetOperations()
        {
            var operations = new
            {
                Get = "/sample - Get all items",
                Post = "/sample - Create an item (body: string)",
                Put = "/sample/{id} - Update an item (body: string)",
                Delete = "/sample/{id} - Delete an item"
            };

            return Ok(operations);
        }
    }
}
