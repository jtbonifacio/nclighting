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
    [Route("api/Monthlies")]
    public class MonthliesController : Controller
    {
        private readonly NCLBackendContext _context;

        public MonthliesController(NCLBackendContext context)
        {
            _context = context;
            if (_context.Monthly.Count() == 0)
            {
                Monthly m1 = new Monthly
                {
                    SALES_REP = "100",
                    SalesAmt = 10000
                };
                Monthly m2 = new Monthly
                {
                    SALES_REP = "110",
                    SalesAmt = 20000
                };
                Monthly m3 = new Monthly
                {
                    SALES_REP = "150",
                    SalesAmt = 30000
                };
                _context.Monthly.Add(m1);
                _context.SaveChanges();
                _context.Monthly.Add(m2);
                _context.SaveChanges();
                _context.Monthly.Add(m3);
                _context.SaveChanges();
            }
        }

        // GET: api/Monthlies
        [HttpGet]
        public IEnumerable<Monthly> GetMonthly()
        {
            return _context.Monthly.ToList();
        }

        // GET: api/Monthlies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMonthly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var monthly = await _context.Monthly.SingleOrDefaultAsync(m => m.Id == id);

            if (monthly == null)
            {
                return NotFound();
            }

            return Ok(monthly);
        }

        // PUT: api/Monthlies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonthly([FromRoute] int id, [FromBody] Monthly monthly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != monthly.Id)
            {
                return BadRequest();
            }

            _context.Entry(monthly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonthlyExists(id))
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

        // POST: api/Monthlies
        [HttpPost]
        public async Task<IActionResult> PostMonthly([FromBody] Monthly monthly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Monthly.Add(monthly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonthly", new { id = monthly.Id }, monthly);
        }

        // DELETE: api/Monthlies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonthly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var monthly = await _context.Monthly.SingleOrDefaultAsync(m => m.Id == id);
            if (monthly == null)
            {
                return NotFound();
            }

            _context.Monthly.Remove(monthly);
            await _context.SaveChangesAsync();

            return Ok(monthly);
        }

        private bool MonthlyExists(int id)
        {
            return _context.Monthly.Any(e => e.Id == id);
        }
    }
}