using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PACPTCodeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PACPTCodeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL PACPTCodes for a PA Record *****
        // <baseurl>/api/pacptcodes
        [HttpGet("{paId}"), Authorize]
        public IActionResult Get(int paId)
        {
            var pacptcodes = _context.PACPTCodes.Where(pc => pc.PARecordId == paId).ToList();
            if (pacptcodes == null)
            {
                return NotFound();
            }
            return Ok(pacptcodes);
        }
        // ***** GET A PACPTCode by Composite Key *****
        // <baseurl>/api/pacptcode
        [HttpGet("{paId}/{id}"), Authorize]
        public IActionResult GetById(int paId, int id)
        {
            var pacptcode = _context.PACPTCodes
                .Where(pc => pc.PARecordId == paId && pc.PACPTId == id)
                .SingleOrDefault();
            return Ok(pacptcode);
        }
        // ***** ADD A PACPTCode *****
        // POST /api/pacptcode
        [HttpPost("{paId}"), Authorize]
        public IActionResult Post(int paId, [FromBody] PACPTCode value)
        {
            _context.PACPTCodes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** DELETE A PACPTCode *****
        // DELETE /api/pacptcode
        [HttpDelete("{paId}/{id}"), Authorize]
        public IActionResult Delete(int paId, int id)
        {

            var pacptcode = _context.PACPTCodes.Where(pc => pc.PARecordId == paId && pc.PACPTId == id).SingleOrDefault();
            if (pacptcode == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.PACPTCodes.Remove(pacptcode);
            _context.SaveChanges();
            return StatusCode(204, pacptcode);
        }
    }
}
