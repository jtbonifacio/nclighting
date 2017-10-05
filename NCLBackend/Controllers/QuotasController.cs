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
    [Route("api/Quotas")]
    public class QuotasController : Controller
    {
        private readonly NCLBackendContext _context;

        public QuotasController(NCLBackendContext context)
        {
            _context = context;
            if (_context.Quota.Count() == 0)
            {
                Quotas o1 = new Quotas
                {
                    SALES_REP = "100",
                    YEARLY_QUOTA = 10000000,
                    MONTHLY_QUOTA = 83333,
                    REPNAME = "JAMES PADOLINA"
                };
                Quotas o2 = new Quotas
                {
                    SALES_REP = "110",
                    YEARLY_QUOTA = 12000000,
                    MONTHLY_QUOTA = 166667,
                    REPNAME = "BARTON FLOJO"
                };
                Quotas o3 = new Quotas
                {
                    SALES_REP = "150",
                    YEARLY_QUOTA = 12000,
                    MONTHLY_QUOTA = 1200,
                    REPNAME = "CAROLINE DOAN"
                };
                _context.Quota.Add(o1);
                _context.SaveChanges();
                _context.Quota.Add(o2);
                _context.SaveChanges();
                _context.Quota.Add(o3);
                _context.SaveChanges();
            }
        }

        // GET: api/Quotas
        [HttpGet]
        public IEnumerable<Quotas> GetQuota()
        {
            return _context.Quota.ToList();
        }

        // GET: api/Quotas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuotas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quotas = await _context.Quota.SingleOrDefaultAsync(m => m.Id == id);

            if (quotas == null)
            {
                return NotFound();
            }

            return Ok(quotas);
        }

        // PUT: api/Quotas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuotas([FromRoute] int id, [FromBody] Quotas quotas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quotas.Id)
            {
                return BadRequest();
            }

            _context.Entry(quotas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuotasExists(id))
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

        // POST: api/Quotas
        [HttpPost]
        public async Task<IActionResult> PostQuotas([FromBody] Quotas quotas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Quota.Add(quotas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuotas", new { id = quotas.Id }, quotas);
        }

        // DELETE: api/Quotas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuotas([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quotas = await _context.Quota.SingleOrDefaultAsync(m => m.Id == id);
            if (quotas == null)
            {
                return NotFound();
            }

            _context.Quota.Remove(quotas);
            await _context.SaveChangesAsync();

            return Ok(quotas);
        }

        private bool QuotasExists(int id)
        {
            return _context.Quota.Any(e => e.Id == id);
        }
    }
}