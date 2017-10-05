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
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly NCLBackendContext _context;

        public UsersController(NCLBackendContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                Users u1 = new Users
                {
                    FIRSTNAME = "JAY",
                    LASTNAME = "BONIFACIO",
                    LOGIN = "JAY",
                    PASSWORD = "JAY2",
                    POSITION = "IT DUDE"
                };
                Users u2 = new Users
                {
                    FIRSTNAME = "JAMES",
                    LASTNAME = "PADOLINA",
                    LOGIN = "JAMES",
                    PASSWORD = "JAMES",
                    POSITION = "IT DUDE 2"
                };

                Users u3 = new Users
                {
                    FIRSTNAME = "BARTON",
                    LASTNAME = "FLOJO",
                    LOGIN = "BARTON",
                    PASSWORD = "BARTON",
                    POSITION = "IT DUDE 3"
                };

                _context.Users.Add(u1);
                _context.SaveChanges();
                _context.Users.Add(u2);
                _context.SaveChanges();
                _context.Users.Add(u3);
                _context.SaveChanges();
            }
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<Users> GetUsers()
        {
            return _context.Users.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers([FromRoute] int id, [FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] Users users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var users = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return Ok(users);
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}