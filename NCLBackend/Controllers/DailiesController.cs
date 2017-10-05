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
    [Route("api/Dailies")]
    public class DailiesController : Controller
    {
        private readonly NCLBackendContext _context;

        public DailiesController(NCLBackendContext context)
        {
            _context = context;

            if (_context.Daily.Count() == 0)
            {
                Daily d1 = new Daily
                {
                    DATE = new DateTime(2017, 9, 15),
                    SALES_REP = "100",
                    SalesAmt = 1000
                };
                Daily d2 = new Daily
                {
                    DATE = new DateTime(2016, 6, 12),
                    SALES_REP = "110",
                    SalesAmt = 2000
                };
                Daily d3 = new Daily
                {
                    DATE = new DateTime(2003, 4, 10),
                    SALES_REP = "150",
                    SalesAmt = 3000
                };
                _context.Daily.Add(d1);
                _context.SaveChanges();
                _context.Daily.Add(d2);
                _context.SaveChanges();
                _context.Daily.Add(d3);
                _context.SaveChanges();
            }
        }

        // GET: api/Dailies
        [HttpGet]
        public IEnumerable<Daily> GetDaily()
        {
            return _context.Daily.ToList();
        }

        // GET: api/Dailies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDaily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var daily = await _context.Daily.SingleOrDefaultAsync(m => m.Id == id);

            if (daily == null)
            {
                return NotFound();
            }

            return Ok(daily);
        }

        // PUT: api/Dailies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDaily([FromRoute] int id, [FromBody] Daily daily)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != daily.Id)
            {
                return BadRequest();
            }

            _context.Entry(daily).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DailyExists(id))
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

        // POST: api/Dailies
        [HttpPost]
        public async Task<IActionResult> PostDaily([FromBody] Daily daily)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Daily.Add(daily);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDaily", new { id = daily.Id }, daily);
        }

        // DELETE: api/Dailies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDaily([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var daily = await _context.Daily.SingleOrDefaultAsync(m => m.Id == id);
            if (daily == null)
            {
                return NotFound();
            }

            _context.Daily.Remove(daily);
            await _context.SaveChangesAsync();

            return Ok(daily);
        }

        private bool DailyExists(int id)
        {
            return _context.Daily.Any(e => e.Id == id);
        }
    }
}