using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPTCodeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CPTCodeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL Records *****
        // <baseurl>/api/cptcodes
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var cptCodes = _context.CPTCodes.ToList();
            if (cptCodes == null)
            {
                return NotFound();
            }
            return Ok(cptCodes);
        }
        // ***** GET By Code/ID *****
        // <baseurl>/api/cptcodes
        [HttpGet("{CPTCodeId}"), Authorize]
        public IActionResult GetById(int cptCodeId)
        {
            var cptItem = _context.CPTCodes.Where(p => p.CPTCodeId == cptCodeId).SingleOrDefault();
            return Ok(cptItem);
        }
        // ***** ADD CPTCode *****
        // POST /api/cptcodes
        [HttpPost, Authorize]
        public IActionResult Post([FromBody]CPTCode value)
        {
            _context.CPTCodes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPPDATE CPTCode *****
        // PUT /api/cptcodes
        [HttpPut("{CPTCodeId}"), Authorize]
        public IActionResult Put(int cptCodeId, [FromBody]CPTCode value)
        {

            var cptCode = _context.CPTCodes.Where(p => p.CPTCodeId == cptCodeId).SingleOrDefault();
            if (cptCode == null)
            {
                return NotFound("Requested record not found.");
            }
            cptCode.CPTDescription = value.CPTDescription;
            _context.CPTCodes.Update(cptCode);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** DELETE CPTCode *****
        // DELETE /api/cptcodes
        [HttpDelete("{CPTCodeId}"), Authorize]
        public IActionResult Delete(int cptCodeId)
        {

            var cptCode = _context.CPTCodes.Where(p => p.CPTCodeId == cptCodeId).SingleOrDefault();
            if (cptCode == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.CPTCodes.Remove(cptCode);
            _context.SaveChanges();
            return StatusCode(204, cptCode);
        }
    }
    
}