using Microsoft.AspNetCore.Mvc;
using HotelCheckInSystem.Data;
using HotelCheckInSystem.Models; // Ensure this line is present

namespace HotelCheckInSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly HotelContext _context;

        public LoginController(HotelContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if (model == null || string.IsNullOrEmpty(model.Login) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { success = false, message = "Invalid input" });
            }

            var user = _context.LoginTable.SingleOrDefault(u => u.Login == model.Login);
            if (user != null && user.Password == model.Password) // Plain-text comparison
            {
                return Ok(new { success = true, message = "Login successful" });
            }

            return Unauthorized(new { success = false, message = "Invalid login or password" });
        }
    }
}