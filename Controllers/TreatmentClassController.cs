using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreatmentClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public TreatmentClassController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL Treatments-Therapies *****
        // <baseurl>/api/treatmentClass
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var treatments = _context.TreatmentClass.ToList();
            if (treatments == null)
            {
                return NotFound();
            }
            return Ok(treatments);
        }
        // ***** GET A Treatment-Therapy by ID *****
        // <baseurl>/api/treatmentClass
        [HttpGet("{code}"), Authorize]
        public IActionResult GetById(string code)
        {
            var treatment = _context.TreatmentClass.Where(p => p.TreatmentCode == code).SingleOrDefault();
            return Ok(treatment);
        }
        // ***** ADD A Treatment-Therapy *****
        // POST /api/treatmentClass
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] Treatment value)
        {
            _context.TreatmentClass.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Treatment-Therapy *****
        // PUT /api/treatmentClass
        [HttpPut("{code}"), Authorize]
        public IActionResult Put(string code, [FromBody] Treatment value)
        {
            var treatment = _context.TreatmentClass.Where(p => p.TreatmentCode == code).SingleOrDefault();
            if (treatment == null)
            {
                return NotFound("Requested record not found.");
            }
            treatment.TreatmentName = value.TreatmentName;

            _context.TreatmentClass.Update(treatment);
            _context.SaveChanges();
            return StatusCode(201, treatment);
        }


        // ***** DELETE A Treatment-Therapy *****
        // DELETE /api/treatmentClass
        [HttpDelete("{code}"), Authorize]
        public IActionResult Delete(string code)
        {

            var treatment = _context.TreatmentClass.Where(p => p.TreatmentCode == code).SingleOrDefault();
            if (treatment == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.TreatmentClass.Remove(treatment);
            _context.SaveChanges();
            return StatusCode(204, treatment);
        }
    }
}
