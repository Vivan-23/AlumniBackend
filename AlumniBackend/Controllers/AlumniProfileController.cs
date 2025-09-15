using AlumniBackend.DATA;
using AlumniBackend.DTOs;
using AlumniBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using System.Security.Claims;

namespace AlumniBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumniProfileController: ControllerBase
    {
        private readonly AppDbContext _context;
        public AlumniProfileController(AppDbContext context)
        {
            _context = context;
        }
        [Authorize]
        [HttpPost]
        public IActionResult UpdateAlumniInfo([FromBody] AlumniProfileUpdate info)
        {
            if (info == null || string.IsNullOrEmpty(info.AlumniName) || info.Passout_year == null)
                return BadRequest("Enter valid info");


            var userNameClaim = User.FindFirst("UserName")?.Value;
            if (string.IsNullOrEmpty(userNameClaim)) return Unauthorized("UserName missing in token");
            var user = _context.Users.FirstOrDefault(u => u.UserName == userNameClaim);
            if (user == null) return NotFound("User not found");

            var userId = user.UserId;

            var profile = new AlumniProfile
            {
                AlumniName = info.AlumniName,
                CompanyName = info.CompanyName,
                Designation = info.Designation,
                linkedinurl = info.linkedinurl,
                Passout_year = info.Passout_year,
                UserId = (int)userId
            };

            _context.AlumniProfiles.Add(profile);
            _context.SaveChanges();
            return Ok("AlumniProfile saved successfully");
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAlumniInfo()
        {
            

            var userNameClaim = User.FindFirst("UserName")?.Value;
            if (string.IsNullOrEmpty(userNameClaim)) return Unauthorized("UserName missing in token");
            var user = _context.Users.FirstOrDefault(u => u.UserName == userNameClaim);
            if (user == null) return NotFound("User not found");

            var userId = user.UserId;

            var alum = _context.AlumniProfiles.FirstOrDefault(s => s.UserId == userId);
            if (alum == null) return NotFound("Alumni profile not found");

            var result = new
            {
                UserName = user.UserName,
                Email = user.Email,
                Phone = user.Phone,
                AlumniName = alum.AlumniName,
                CompanyName = alum.CompanyName,
                Designation = alum.Designation,
                Passout_Year = alum.Passout_year,
                Linkedin = alum.linkedinurl
            };

            return Ok(result);
        }

    }
}
