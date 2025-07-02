using BakasuraAddaFoodStreet.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BakasuraAddaFoodStreet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterUserController : ControllerBase
    {
        private readonly FoodStreetDbContext _context;
        public MasterUserController(FoodStreetDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.PasswordHash))
                return BadRequest("Email and password are required.");

            var user = await _context.MasterUser
                .FirstOrDefaultAsync(u => u.Email == request.Email && u.PasswordHash == request.PasswordHash);

            if (user == null)
                return Unauthorized("Invalid credentials.");

            return Ok(new
            {
                message = "Login successful",
                userId = user.UserID,
                email = user.Email,
                isActive = user.IsActive
            });
        }

    }
}
