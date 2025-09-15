using AlumniBackend.DATA;
using AlumniBackend.DTOs;
using AlumniBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static AlumniBackend.DTOs.RoleElevation;
using static AlumniBackend.Models.User;

namespace AlumniBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context; 
        }
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserCreation user )
        {
            if(user == null ) return BadRequest("User missing");

            var password = user.Passwordhash;
            var passhashed = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
            var User = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                Passwordhash = passhashed               
            };
            _context.Add(User);
            _context.SaveChanges();
            return Ok("User Creation Successful");
        }
        [HttpPatch("ElevateRole")]
        public IActionResult ElevateRoles([FromBody] RoleElevation re)
        {
            var user = _context.Users.FirstOrDefault(s => s.UserName == re.UserName);
            if (user == null) return BadRequest("user not found");
            var newrole = _context.Roles.FirstOrDefault(s => s.RoleName == re.Role);
            if (newrole.RoleName == null) return BadRequest(string.Empty);

            user.Role = newrole;
            _context.SaveChanges();
            return Ok("user updated");
        }
        [HttpGet("GetUser")]
        public IActionResult GetUser(string email)
        {
            var user = _context.Users.FirstOrDefault(s => s.UserName == email);
            if (user == null) return BadRequest("User Details not found");
            return Ok(user);
        }
    }
}
