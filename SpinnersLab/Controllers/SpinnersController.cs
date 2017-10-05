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
    [Route("api/Spinners")]
    public class SpinnersController : Controller
    {
        private readonly SpinnersContext _context;

        public SpinnersController(SpinnersContext context)
        {
            _context = context;

            if (_context.Spinners.Count() == 0)
            {
                Spinner s1 = new Spinner
                {
                    Id = 1,
                    Model = "Basic",
                    Type = "Red",
                    Price = 15,
                    Img = "https://cf1.s3.souqcdn.com/item/2017/03/06/22/14/84/98/item_XL_22148498_29488198.jpg"
                };

                Spinner s2 = new Spinner
                {
                    Id = 2,
                    Model = "Basic",
                    Type = "Blue",
                    Price = 15,
                    Img = "https://cf1.s3.souqcdn.com/item/2017/03/06/22/14/85/09/item_XL_22148509_29488234.jpg"
                };

                Spinner s3 = new Spinner
                {
                    Id = 3,
                    Model = "Basic",
                    Type = "Green",
                    Price = 15,
                    Img = "https://images.hobbytron.com/ZX-33138-lg.jpg"
                };

                Spinner s4 = new Spinner
                {
                    Id = 4,
                    Model = "Basic",
                    Type = "Black",
                    Price = 15,
                    Img = "https://images-eu.ssl-images-amazon.com/images/I/71RrvbNgoDL._SL1500_.jpg"
                };

                Spinner s5 = new Spinner
                {
                    Id = 5,
                    Model = "Basic",
                    Type = "Yellow",
                    Price = 15,
                    Img = "https://s-media-cache-ak0.pinimg.com/originals/99/98/60/999860236235b4105dabaa744b7eccf8.gif"
                };

                Spinner s6 = new Spinner
                {
                    Id = 6,
                    Model = "Basic",
                    Type = "Pink",
                    Price = 15,
                    Img = "https://ae01.alicdn.com/kf/HTB19x0VQXXXXXXzXVXXq6xXFXXXG/220721042/HTB19x0VQXXXXXXzXVXXq6xXFXXXG.jpg"
                };

                Spinner l1 = new Spinner
                {
                    Id = 7,
                    Model = "LED",
                    Type = "Red",
                    Price = 15,
                    Img = "https://sc01.alicdn.com/kf/HTB1Bf2.RXXXXXb_XpXXq6xXFXXXX/205816583/HTB1Bf2.RXXXXXb_XpXXq6xXFXXXX.jpg"
                };

                Spinner l2 = new Spinner
                {
                    Id = 8,
                    Model = "LED",
                    Type = "Blue",
                    Price = 15,
                    Img = "http://wxalbum-10001658.image.myqcloud.com/wxalbum/122726/20170601233839/42ba8a0a4848cab12fc876d0beb852d4.gif"
                };

                Spinner l3 = new Spinner
                {
                    Id = 9,
                    Model = "LED",
                    Type = "Green",
                    Price = 15,
                    Img = "https://www.dpciwholesale.com/images/D/9811-motion.gif"
                };

                Spinner l4 = new Spinner
                {
                    Id = 10,
                    Model = "LED",
                    Type = "Black",
                    Price = 15,
                    Img = "https://www.dpciwholesale.com/images/D/LED-Spinner-06.gif"
                };

                Spinner l5 = new Spinner
                {
                    Id = 11,
                    Model = "LED",
                    Type = "Yellow",
                    Price = 15,
                    Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ5qhLXglREZ7HcYsaibRCaaYOObb-y4pUn4WA-hr7ZOpSH_ZjN"
                };

                Spinner l6 = new Spinner
                {
                    Id = 12,
                    Model = "LED",
                    Type = "Pink",
                    Price = 15,
                    Img = "https://sc01.alicdn.com/kf/HTB1Bf2.RXXXXXb_XpXXq6xXFXXXX/205816583/HTB1Bf2.RXXXXXb_XpXXq6xXFXXXX.jpg"
                };

                _context.Spinners.Add(s1);
                _context.SaveChanges();
                _context.Spinners.Add(s2);
                _context.SaveChanges();
                _context.Spinners.Add(s3);
                _context.SaveChanges();
                _context.Spinners.Add(s4);
                _context.SaveChanges();
                _context.Spinners.Add(s5);
                _context.SaveChanges();
                _context.Spinners.Add(s6);
                _context.SaveChanges();
                _context.Spinners.Add(l1);
                _context.SaveChanges();
                _context.Spinners.Add(l2);
                _context.SaveChanges();
                _context.Spinners.Add(l3);
                _context.SaveChanges();
                _context.Spinners.Add(l4);
                _context.SaveChanges();
                _context.Spinners.Add(l5);
                _context.SaveChanges();
                _context.Spinners.Add(l6);
                _context.SaveChanges();
            }
            
        }

        // GET: api/Spinners
        [HttpGet]
        public List<Spinner> GetSpinners()
        {
            return _context.Spinners.ToList();
        }

        // GET: api/Spinners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpinner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spinner = await _context.Spinners.SingleOrDefaultAsync(m => m.Id == id);

            if (spinner == null)
            {
                return NotFound();
            }

            return Ok(spinner);
        }

        // PUT: api/Spinners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpinner([FromRoute] int id, [FromBody] Spinner spinner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spinner.Id)
            {
                return BadRequest();
            }

            _context.Entry(spinner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpinnerExists(id))
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

        // POST: api/Spinners
        [HttpPost]
        public async Task<IActionResult> PostSpinner([FromBody] Spinner spinner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Spinners.Add(spinner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpinner", new { id = spinner.Id }, spinner);
        }

        // DELETE: api/Spinners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpinner([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spinner = await _context.Spinners.SingleOrDefaultAsync(m => m.Id == id);
            if (spinner == null)
            {
                return NotFound();
            }

            _context.Spinners.Remove(spinner);
            await _context.SaveChangesAsync();

            return Ok(spinner);
        }

        private bool SpinnerExists(int id)
        {
            return _context.Spinners.Any(e => e.Id == id);
        }
    }
}