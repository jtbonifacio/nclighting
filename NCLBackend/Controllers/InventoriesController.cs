using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NCLBackend.Models;

namespace NCLBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/Inventories")]
    public class InventoriesController : Controller
    {
        private readonly NCLBackendContext _context;

        public InventoriesController(NCLBackendContext context)
        {
            _context = context;

            if (_context.Inventory.Count() == 0)
            {
                Inventory i1 = new Inventory
                {
                    ITEM = "Item1",
                    ITEM_DESC = "First item on list",
                    ON_HAND_QTY = 25,
                    STATUS = "A",
                    PRICE = 50,
                    IMAGE = ""
                };
                Inventory i2 = new Inventory
                {
                    ITEM = "Item2",
                    ITEM_DESC = "Second item on list",
                    ON_HAND_QTY = 30,
                    STATUS = "A",
                    PRICE = 150,
                    IMAGE = ""
                };
                Inventory i3 = new Inventory
                {
                    ITEM = "Item3",
                    ITEM_DESC = "Third item on list",
                    ON_HAND_QTY = 500,
                    STATUS = "A",
                    PRICE = 1500,
                    IMAGE = ""
                };
                _context.Inventory.Add(i1);
                _context.SaveChanges();
                _context.Inventory.Add(i2);
                _context.SaveChanges();
                _context.Inventory.Add(i3);
                _context.SaveChanges();
            }
        }

        // GET: api/Inventories
        [HttpGet]
        public IEnumerable<Inventory> GetInventory()
        {
            return _context.Inventory.ToList();
        }

        // GET: api/Inventories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = await _context.Inventory.SingleOrDefaultAsync(m => m.Id == id);

            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // PUT: api/Inventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory([FromRoute] int id, [FromBody] Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inventory.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Inventories
        [HttpPost]
        public async Task<IActionResult> PostInventory([FromBody] Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.Id }, inventory);
        }

        // DELETE: api/Inventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var inventory = await _context.Inventory.SingleOrDefaultAsync(m => m.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();

            return Ok(inventory);
        }

        private bool InventoryExists(int id)
        {
            return _context.Inventory.Any(e => e.Id == id);
        }
    }
}