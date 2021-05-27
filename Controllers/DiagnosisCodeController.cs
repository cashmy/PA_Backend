using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosisCodeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DiagnosisCodeController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL Records *****
        // <baseurl>/api/diagnosisCode
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var diagCodes = _context.DiagnosisCodes.ToList();
            if (diagCodes == null)
            {
                return NotFound();
            }
            return Ok(diagCodes);
        }
        // ***** GET By Code/ID *****
        // <baseurl>/api/diagnosisCode
        [HttpGet("{DiagCode}"), Authorize]
        public IActionResult GetById(string diagCode)
        {
            var diagnosis = _context.DiagnosisCodes.Where(p => p.DiagCode == diagCode).SingleOrDefault();
            return Ok(diagnosis);
        }
        // ***** ADD A Diagnosis *****
        // POST /api/diagnosisCode
        [HttpPost, Authorize]
        public IActionResult Post([FromBody]DiagnosisCode value)
        {
            _context.DiagnosisCodes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPPDATE a Diagnosis *****
        // PUT /api/diagnosisCode
        [HttpPut("{DiagCode}"), Authorize]
        public IActionResult Put(string diagCode, [FromBody]DiagnosisCode value)
        {

            var diagItem = _context.DiagnosisCodes.Where(d => d.DiagCode == diagCode).SingleOrDefault();
            if (diagItem == null)
            {
                return NotFound("Requested record not found.");
            }
            diagItem.DiagDescription = value.DiagDescription;
            _context.DiagnosisCodes.Update(diagItem);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** DELETE A Diagnosis *****
        // DELETE /api/diagnosisCode
        [HttpDelete("{DiagCode}"), Authorize]
        public IActionResult Delete(string diagCode)
        {

            var diagItem = _context.DiagnosisCodes.Where(p => p.DiagCode == diagCode).SingleOrDefault();
            if (diagItem == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.DiagnosisCodes.Remove(diagItem);
            _context.SaveChanges();
            return StatusCode(204, diagItem);
        }
    }
}
