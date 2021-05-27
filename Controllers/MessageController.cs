using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public MessageController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL Messages for a User *****
        // <baseurl>/api/messages
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Where(u => u.Id == userId);

            if (user == null)
            {
                return NotFound("User not found");
            }

            var messages = _context.Messages.Where(m => m.UserId == userId).ToList();
            if (messages == null)
            {
                return NotFound("Messages not found");
            }
            return Ok(messages);
        }

        // ***** GET A Message by Composite Key *****
        // <baseurl>/api/message
        [HttpGet("{id}"), Authorize]
        public IActionResult GetById(int id)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Where(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var message = _context.Messages.Where(m => m.UserId == userId && m.MessageId == id).SingleOrDefault();
            return Ok(message);
        }
        // ***** ADD A Message *****
        // POST /api/message
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Message value)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Where(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            value.UserId = userId;
            _context.Messages.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Message *****
        // PUT /api/message
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] Message value)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Where(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var message = _context.Messages.Where(m => m.UserId == userId && m.MessageId == id).SingleOrDefault();
            if (message == null)
            {
                return NotFound("Requested record not found.");
            }

            message.MessageText = value.MessageText;

            _context.Messages.Update(message);
            _context.SaveChanges();
            return StatusCode(201, message);
        }


        // ***** DELETE A Message *****
        // DELETE /api/message
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int paId, int id)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Where(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var message = _context.Messages.Where(m => m.UserId == userId && m.MessageId == id).SingleOrDefault();
            if (message == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Messages.Remove(message);
            _context.SaveChanges();
            return StatusCode(204, message);
        }
    }
}
