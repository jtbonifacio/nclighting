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
    [Route("api/Weeklies")]
    public class WeekliesController : Controller
    {
        private readonly NCLBackendContext _context;

        public WeekliesController(NCLBackendContext context)
        {
            _context = context;

            if (_context.Weekly.Count() == 0)
            {
                Weekly w1 = new Weekly
                {
                    SALES_REP = "100",
                    SalesAmt = 1005
                };
                Weekly w2 = new Weekly
                {
                    SALES_REP = "110",
                    SalesAmt = 2005
                };
                Weekly w3 = new Weekly
                {
                    SALES_REP = "150",
                    SalesAmt = 3005
                };
                _context.Weekly.Add(w1);
                _context.SaveChanges();
                _context.Weekly.Add(w2);
                _context.SaveChanges();
                _context.Weekly.Add(w3);
                _context.SaveChanges();
            }
        }

        // GET: api/Weeklies
        [HttpGet]
        public IEnumerable<Weekly> GetWeekly()
        {
            return _context.Weekly.ToList();
        }

        // GET: api/Weeklies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeekly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weekly = await _context.Weekly.SingleOrDefaultAsync(m => m.Id == id);

            if (weekly == null)
            {
                return NotFound();
            }

            return Ok(weekly);
        }

        // PUT: api/Weeklies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeekly([FromRoute] int id, [FromBody] Weekly weekly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != weekly.Id)
            {
                return BadRequest();
            }

            _context.Entry(weekly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeeklyExists(id))
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

        // POST: api/Weeklies
        [HttpPost]
        public async Task<IActionResult> PostWeekly([FromBody] Weekly weekly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Weekly.Add(weekly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeekly", new { id = weekly.Id }, weekly);
        }

        // DELETE: api/Weeklies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeekly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var weekly = await _context.Weekly.SingleOrDefaultAsync(m => m.Id == id);
            if (weekly == null)
            {
                return NotFound();
            }

            _context.Weekly.Remove(weekly);
            await _context.SaveChangesAsync();

            return Ok(weekly);
        }

        private bool WeeklyExists(int id)
        {
            return _context.Weekly.Any(e => e.Id == id);
        }
    }
}