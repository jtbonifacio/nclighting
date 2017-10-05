﻿using System;
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
    [Route("api/Sales")]
    public class SalesController : Controller
    {
        private readonly SpinnersContext _context;

        public SalesController(SpinnersContext context)
        {
            _context = context;

            if (_context.Sale.Count() == 0)
            {
                Sale s = new Sale
                {
                    Id = 1,
                    mySpinner = new Spinner
                    {
                        Id = 1,
                        Model = "Red",
                        Type = "Basic",
                        Img = ""
                    }
                };

                _context.Sale.Add(s);
                _context.SaveChanges();
            }
        }

        // GET: api/Sales
        [HttpGet]
        public List<Sale> GetSale()
        {
            return _context.Sale.ToList();
        }

        // GET: api/Sales/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.Id == id);

            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/Sales/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSale([FromRoute] int id, [FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.Id)
            {
                return BadRequest();
            }

            _context.Entry(sale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
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

        // POST: api/Sales
        [HttpPost]
        public async Task<IActionResult> PostSale([FromBody] Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sale.Add(sale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSale", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sale = await _context.Sale.SingleOrDefaultAsync(m => m.Id == id);
            if (sale == null)
            {
                return NotFound();
            }

            _context.Sale.Remove(sale);
            await _context.SaveChangesAsync();

            return Ok(sale);
        }

        private bool SaleExists(int id)
        {
            return _context.Sale.Any(e => e.Id == id);
        }
    }
}