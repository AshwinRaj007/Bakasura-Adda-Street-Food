using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BakasuraAddaFoodStreet.Model;
using Microsoft.AspNetCore.Cors;

namespace BakasuraAddaFoodStreet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowCors")]
    public class LocalFoodStreetController : ControllerBase
    {
        private readonly FoodStreetDbContext _context;

        public LocalFoodStreetController(FoodStreetDbContext context)
        {
            _context = context;
        }

        // GET: api/LocalFoodStreet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalFoodStreet>>> GetLocalFoodStreets()
        {
            return await _context.LocalFoodStreet.ToListAsync();
        }

        // GET: api/LocalFoodStreet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocalFoodStreet>> GetLocalFoodStreet(int id)
        {
            var localFoodStreet = await _context.LocalFoodStreet.FindAsync(id);

            if (localFoodStreet == null)
            {
                return NotFound();
            }

            return localFoodStreet;
        }

        // PUT: api/LocalFoodStreet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalFoodStreet(int id, LocalFoodStreet localFoodStreet)
        {
            if (id != localFoodStreet.StreetID)
            {
                return BadRequest();
            }

            _context.Entry(localFoodStreet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalFoodStreetExists(id))
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

        // POST: api/LocalFoodStreet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocalFoodStreet>> PostLocalFoodStreet(LocalFoodStreet localFoodStreet)
        {
            _context.LocalFoodStreet.Add(localFoodStreet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalFoodStreet", new { id = localFoodStreet.StreetID }, localFoodStreet);
        }

        // DELETE: api/LocalFoodStreet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalFoodStreet(int id)
        {
            var localFoodStreet = await _context.LocalFoodStreet.FindAsync(id);
            if (localFoodStreet == null)
            {
                return NotFound();
            }

            _context.LocalFoodStreet.Remove(localFoodStreet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalFoodStreetExists(int id)
        {
            return _context.LocalFoodStreet.Any(e => e.StreetID == id);
        }
        //[HttpPost("login")]
        //public async Task<IActionResult> Login([FromBody] LoginRequest request)
        //{
        //    if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        //        return BadRequest("Email and password are required.");

        //    var user = await _context.MasterUser
        //        .FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password); // ✅ Use hashing in real apps

        //    if (user == null)
        //        return Unauthorized("Invalid credentials.");

        //    // ✅ Optionally return a JWT here
        //    return Ok(new { message = "Login successful", userId = user.UserId });
        //}



    }
}
