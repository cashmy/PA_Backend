using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PADiagCodeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PADiagCodeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL PADiagCodes for a PA Record *****
        // <baseurl>/api/padiagcodes
        [HttpGet("{paId}"), Authorize]
        public IActionResult Get(int paId)
        {
            var padiagcodes = _context.PADiagCodes.Where(pc => pc.PARecordId == paId).ToList();
            if (padiagcodes == null)
            {
                return NotFound();
            }
            return Ok(padiagcodes);
        }
        // ***** GET A PADiagCode by Composite Key *****
        // <baseurl>/api/padiagcode
        [HttpGet("{paId}/{id}"), Authorize]
        public IActionResult GetById(int paId, string id)
        {
            var padiagcode = _context.PADiagCodes.Where(pc => pc.PARecordId == paId && pc.PADiagId == id).SingleOrDefault();
            return Ok(padiagcode);
        }
        // ***** ADD A PADiagCode *****
        // POST /api/padiagcode
        [HttpPost("{paId}"), Authorize]
        public IActionResult Post(int paId, [FromBody] PADiagCode value)
        {
            _context.PADiagCodes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** DELETE A PADiagCode *****
        // DELETE /api/padiagcode
        [HttpDelete("{paId}/{id}"), Authorize]
        public IActionResult Delete(int paId, string id)
        {

            var padiagcode = _context.PADiagCodes.Where(pc => pc.PARecordId == paId && pc.PADiagId == id).SingleOrDefault();
            if (padiagcode == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.PADiagCodes.Remove(padiagcode);
            _context.SaveChanges();
            return StatusCode(204, padiagcode);
        }
    }
}
