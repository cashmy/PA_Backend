using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System;
using System.Globalization;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _context.Users.ToList();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        // GET: api/<UserController>
        [HttpGet("profile"), Authorize]
        public IActionResult GetUserById()
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            try
            {
                var userInfo = _context.Users.Where(u => u.Id == userId).SingleOrDefault();
                return Ok(userInfo);
            }
            catch
            {
                return NotFound();
            }

        }
        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User value)
        {
            _context.Users.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT: api/<UserController>
        [HttpPut, Authorize]
        public IActionResult Put([FromBody] User value)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var userInfo = _context.Users.Where(u => u.Id == userId).SingleOrDefault();

            userInfo.FirstName = value.FirstName;
            userInfo.LastName = value.LastName;
            userInfo.PhoneNumber = value.PhoneNumber;
            userInfo.Email = value.Email;
            userInfo.NormalizedEmail = value.Email.ToUpper(new CultureInfo("en-US", false));
            userInfo.UserName = value.UserName;
            userInfo.NormalizedUserName = value.UserName.ToUpper(new CultureInfo("en-US", false));
            // ** TODO: Rehash incoming password here.
            //userInfo.PasswordHash = Hashed(value.password)


            _context.Users.Update(userInfo);
            _context.SaveChanges();
            return Ok(user);
        }

        // Delete: api/<UserController>
        [HttpDelete("{userId}"), Authorize]
        public IActionResult DeleteUser(string userId)
        {

            try
            {
                var userInfo = _context.Users.Where(u => u.UserName == userId).SingleOrDefault();
                _context.Remove(userInfo);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}
