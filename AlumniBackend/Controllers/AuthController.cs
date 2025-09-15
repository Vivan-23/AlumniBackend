using AlumniBackend.DATA;
using AlumniBackend.DTOs;
using AlumniBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AlumniBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController:ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly AppDbContext _context;
        public AuthController(JwtService jwtService, AppDbContext context)
        {
            _context = context;
            _jwtService = jwtService;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginUser Login)
        {
            var user = _context.Users.FirstOrDefault(s => (s.UserName == Login.UserName) ||(s.Email == Login.Email));
            if (user == null) return BadRequest("No User Found");
            var roleId = _context.Users
                .Where(s => s.UserName == Login.UserName)
                .Select(s => s.RoleId)
                .FirstOrDefault();
            var role = _context.Roles.Where(s => s.RoleId == roleId).Select(s => s.RoleName).FirstOrDefault();
            //if (user.Role == null) return BadRequest($"dwdbwdbh{user.Role}");
            var passhashed = BCrypt.Net.BCrypt.HashPassword(Login.Passwordhash);
            List<Claim> jwtClaims =
           [
                new Claim("UserName", Login.UserName?? string.Empty),
                new Claim("Email",Login.Email ?? string.Empty),
                new Claim("Role", role)

           ];
            var jwt = _jwtService.GenerateToken(jwtClaims);
            //if (passhashed == user.Passwordhash)
            //{
            //    jwt = _jwtService.GenerateToken(jwtClaims);
            //}
            return Ok($"{jwt} \n \t Login Successful");
        }

    }
}
