#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAuth.DBContext;
using UserAuth.Models;

namespace UserAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieReminderAuthenticationController : ControllerBase
    {
        private readonly MovieReminderAuthenticationDbContext _context;

        public MovieReminderAuthenticationController(MovieReminderAuthenticationDbContext context)
        {
            _context = context;
        }

        // GET: api/MovieReminderAuthentication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAuthentication>>> GetUserAuthentications()
        {
            return await _context.UserAuthentications.ToListAsync();
        }

        // GET: api/MovieReminderAuthentication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAuthentication>> GetUserAuthentication(int id)
        {
            var userAuthentication = await _context.UserAuthentications.FindAsync(id);

            if (userAuthentication == null)
            {
                return NotFound();
            }

            return userAuthentication;
        }

        // PUT: api/MovieReminderAuthentication/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAuthentication(int id, UserAuthentication userAuthentication)
        {
            if (id != userAuthentication.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAuthentication).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAuthenticationExists(id))
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

        // POST: api/MovieReminderAuthentication
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserAuthentication>> PostUserAuthentication(UserAuthentication userAuthentication)
        {
            _context.UserAuthentications.Add(userAuthentication);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserAuthenticationExists(userAuthentication.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserAuthentication", new { id = userAuthentication.Id }, userAuthentication);
        }

        // DELETE: api/MovieReminderAuthentication/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAuthentication(int id)
        {
            var userAuthentication = await _context.UserAuthentications.FindAsync(id);
            if (userAuthentication == null)
            {
                return NotFound();
            }

            _context.UserAuthentications.Remove(userAuthentication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserAuthenticationExists(int id)
        {
            return _context.UserAuthentications.Any(e => e.Id == id);
        }
    }
}
