using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PANoteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PANoteController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL PANotes for a PA Record *****
        // <baseurl>/api/panotes
        [HttpGet("{paId}"), Authorize]
        public IActionResult Get(int paId)
        {
            var panotes = _context.PANotes.Where(pn => pn.PARecordId == paId).ToList();
            if (panotes == null)
            {
                return NotFound();
            }
            return Ok(panotes);
        }
        // ***** GET A PANote by Composite Key *****
        // <baseurl>/api/panote
        [HttpGet("{paId}/{id}"), Authorize]
        public IActionResult GetById(int paId, int id)
        {
            var status = _context.PANotes.Where(pn => pn.PARecordId == paId && pn.PANoteId == id).SingleOrDefault();
            return Ok(status);
        }
        // ***** ADD A PANote *****
        // POST /api/panote
        [HttpPost("{paId}"), Authorize]
        public IActionResult Post(int paId, [FromBody] PANote value)
        {
            _context.PANotes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A PANote *****
        // PUT /api/panote
        [HttpPut("{paId}/{id}"), Authorize]
        public IActionResult Put(int paId, int id, [FromBody] PANote value)
        {
            var panote = _context.PANotes.Where(pn => pn.PARecordId == paId && pn.PANoteId == id).SingleOrDefault();
            if (panote == null)
            {
                return NotFound("Requested record not found.");
            }
            panote.PANoteTypeId = value.PANoteTypeId;
            panote.PANoteText = value.PANoteText;
            panote.PANoteUserId = value.PANoteUserId;

            _context.PANotes.Update(panote);
            _context.SaveChanges();
            return StatusCode(201, panote);
        }


        // ***** DELETE A PANote *****
        // DELETE /api/panote
        [HttpDelete("{paId}/{id}"), Authorize]
        public IActionResult Delete(int paId, int id)
        {

            var panote = _context.PANotes.Where(pn => pn.PARecordId == paId && pn.PANoteId == id).SingleOrDefault();
            if (panote == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.PANotes.Remove(panote);
            _context.SaveChanges();
            return StatusCode(204, panote);
        }
    }
}
