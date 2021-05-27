using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StatusController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL Statuses *****
        // <baseurl>/api/status
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var statuses = _context.Statuses.ToList();
            if (statuses == null)
            {
                return NotFound();
            }
            return Ok(statuses);
        }
        // ***** GET A Status by ID *****
        // <baseurl>/api/status
        [HttpGet("{id}"), Authorize]
        public IActionResult GetById(int id)
        {
            var status = _context.Statuses.Where(p => p.StatusId == id).SingleOrDefault();
            return Ok(status);
        }
        // ***** ADD A Status *****
        // POST /api/status
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Status value)
        {
            _context.Statuses.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Status *****
        // PUT /api/status
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] Status value)
        {
            var status = _context.Statuses.Where(p => p.StatusId == id).SingleOrDefault();
            if (status == null)
            {
                return NotFound("Requested record not found.");
            }
            status.StatusName = value.StatusName;
            status.StatusColor = value.StatusColor;
            status.StatusTextColor = value.StatusTextColor;
            status.DisplayOnSummary = value.DisplayOnSummary;

            _context.Statuses.Update(status);
            _context.SaveChanges();
            return StatusCode(201, status);
        }


        // ***** DELETE A Status *****
        // DELETE /api/status
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {

            var status = _context.Statuses.Where(p => p.StatusId == id).SingleOrDefault();
            if (status == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Statuses.Remove(status);
            _context.SaveChanges();
            return StatusCode(204, status);
        }
    }
}

