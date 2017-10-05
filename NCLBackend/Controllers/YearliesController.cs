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
    [Route("api/Yearlies")]
    public class YearliesController : Controller
    {
        private readonly NCLBackendContext _context;

        public YearliesController(NCLBackendContext context)
        {
            _context = context;

            if (_context.Yearly.Count() == 0)
            {
                Yearly y1 = new Yearly
                {
                    SALES_REP = "100",
                    SalesAmt = 10000000
                };
                Yearly y2 = new Yearly
                {
                    SALES_REP = "110",
                    SalesAmt = 20000000
                };
                Yearly y3 = new Yearly
                {
                    SALES_REP = "150",
                    SalesAmt = 3000000
                };
                _context.Yearly.Add(y1);
                _context.SaveChanges();
                _context.Yearly.Add(y2);
                _context.SaveChanges();
                _context.Yearly.Add(y3);
                _context.SaveChanges();
            }
        }

        // GET: api/Yearlies
        [HttpGet]
        public IEnumerable<Yearly> GetYearly()
        {
            return _context.Yearly.ToList();
        }

        // GET: api/Yearlies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetYearly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yearly = await _context.Yearly.SingleOrDefaultAsync(m => m.Id == id);

            if (yearly == null)
            {
                return NotFound();
            }

            return Ok(yearly);
        }

        // PUT: api/Yearlies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutYearly([FromRoute] int id, [FromBody] Yearly yearly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != yearly.Id)
            {
                return BadRequest();
            }

            _context.Entry(yearly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearlyExists(id))
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

        // POST: api/Yearlies
        [HttpPost]
        public async Task<IActionResult> PostYearly([FromBody] Yearly yearly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Yearly.Add(yearly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetYearly", new { id = yearly.Id }, yearly);
        }

        // DELETE: api/Yearlies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYearly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var yearly = await _context.Yearly.SingleOrDefaultAsync(m => m.Id == id);
            if (yearly == null)
            {
                return NotFound();
            }

            _context.Yearly.Remove(yearly);
            await _context.SaveChangesAsync();

            return Ok(yearly);
        }

        private bool YearlyExists(int id)
        {
            return _context.Yearly.Any(e => e.Id == id);
        }
    }
}