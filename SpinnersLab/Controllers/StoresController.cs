using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpinnersLab.Models;

namespace SpinnersLab.Controllers
{
    [Produces("application/json")]
    [Route("api/Stores")]
    public class StoresController : Controller
    {
        private readonly SpinnersContext _context;

        public StoresController(SpinnersContext context)
        {
            _context = context;

            if (_context.Store.Count() == 0)
            {
                Store s = new Store
                {
                    Id = 1,
                    Name = "Walmart",
                    Location = "123 Main",
                    Spinners = new List<Spinner>()
                };

                s.Spinners.Add(new Spinner
                {
                    Id = 1,
                    Model = "Basic",
                    Type = "Red",
                    Img = ""
                });

                _context.Store.Add(s);
                _context.SaveChanges();
            }
        }

        // GET: api/Stores
        [HttpGet]
        public List<Store> GetStore()
        {
            return _context.Store.ToList();
        }

        // GET: api/Stores/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStore([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _context.Store.SingleOrDefaultAsync(m => m.Id == id);

            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        // PUT: api/Stores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStore([FromRoute] int id, [FromBody] Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.Id)
            {
                return BadRequest();
            }

            _context.Entry(store).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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

        // POST: api/Stores
        [HttpPost]
        public async Task<IActionResult> PostStore([FromBody] Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Store.Add(store);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStore", new { id = store.Id }, store);
        }

        // DELETE: api/Stores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var store = await _context.Store.SingleOrDefaultAsync(m => m.Id == id);
            if (store == null)
            {
                return NotFound();
            }

            _context.Store.Remove(store);
            await _context.SaveChangesAsync();

            return Ok(store);
        }

        private bool StoreExists(int id)
        {
            return _context.Store.Any(e => e.Id == id);
        }
    }
}