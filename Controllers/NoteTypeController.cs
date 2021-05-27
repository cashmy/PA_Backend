using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public NoteTypeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL NoteTypes *****
        // <baseurl>/api/noteType
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var noteTypes = _context.NoteTypes.ToList();
            if (noteTypes == null)
            {
                return NotFound();
            }
            return Ok(noteTypes);
        }
        // ***** GET A NoteType by ID *****
        // <baseurl>/api/noteType
        [HttpGet("{id}"), Authorize]
        public IActionResult GetById(int id)
        {
            var noteType = _context.NoteTypes.Where(p => p.NoteTypeId == id).SingleOrDefault();
            return Ok(noteType);
        }
        // ***** ADD A NoteType *****
        // POST /api/noteType
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] NoteType value)
        {
            _context.NoteTypes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A NoteType *****
        // PUT /api/noteType
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] NoteType value)
        {
            var noteType = _context.NoteTypes.Where(p => p.NoteTypeId == id).SingleOrDefault();
            if (noteType == null)
            {
                return NotFound("Requested record not found.");
            }
            noteType.NoteTypeName = value.NoteTypeName;

            _context.NoteTypes.Update(noteType);
            _context.SaveChanges();
            return StatusCode(201, noteType);
        }


        // ***** DELETE A NoteType *****
        // DELETE /api/noteType
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {

            var noteType = _context.NoteTypes.Where(p => p.NoteTypeId == id).SingleOrDefault();
            if (noteType == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.NoteTypes.Remove(noteType);
            _context.SaveChanges();
            return StatusCode(204, noteType);
        }
    }
}
