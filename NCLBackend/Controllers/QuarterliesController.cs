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
    [Route("api/Quarterlies")]
    public class QuarterliesController : Controller
    {
        private readonly NCLBackendContext _context;

        public QuarterliesController(NCLBackendContext context)
        {
            _context = context;

            if (_context.Quarterly.Count() == 0)
            {
                Quarterly q1 = new Quarterly
                {
                    SALES_REP = "100",
                    SalesAmt = 1000
                };
                Quarterly q2 = new Quarterly
                {
                    SALES_REP = "110",
                    SalesAmt = 2000
                };
                Quarterly q3 = new Quarterly
                {
                    SALES_REP = "150",
                    SalesAmt = 3000
                };
                _context.Quarterly.Add(q1);
                _context.SaveChanges();
                _context.Quarterly.Add(q2);
                _context.SaveChanges();
                _context.Quarterly.Add(q3);
                _context.SaveChanges();
            }

        }

        // GET: api/Quarterlies
        [HttpGet]
        public IEnumerable<Quarterly> GetQuarterly()
        {
            return _context.Quarterly.ToList();
        }

        // GET: api/Quarterlies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuarterly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quarterly = await _context.Quarterly.SingleOrDefaultAsync(m => m.Id == id);

            if (quarterly == null)
            {
                return NotFound();
            }

            return Ok(quarterly);
        }

        // PUT: api/Quarterlies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuarterly([FromRoute] int id, [FromBody] Quarterly quarterly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quarterly.Id)
            {
                return BadRequest();
            }

            _context.Entry(quarterly).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuarterlyExists(id))
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

        // POST: api/Quarterlies
        [HttpPost]
        public async Task<IActionResult> PostQuarterly([FromBody] Quarterly quarterly)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Quarterly.Add(quarterly);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuarterly", new { id = quarterly.Id }, quarterly);
        }

        // DELETE: api/Quarterlies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuarterly([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quarterly = await _context.Quarterly.SingleOrDefaultAsync(m => m.Id == id);
            if (quarterly == null)
            {
                return NotFound();
            }

            _context.Quarterly.Remove(quarterly);
            await _context.SaveChangesAsync();

            return Ok(quarterly);
        }

        private bool QuarterlyExists(int id)
        {
            return _context.Quarterly.Any(e => e.Id == id);
        }
    }
}