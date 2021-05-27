using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PatientController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ClinicController>
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var patients = _context.Patients.ToList();
            if (patients == null)
            {
                return NotFound();
            }
            return Ok(patients);
        }

        // GET api/<ClinicController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clinic = _context.Patients.Where(p => p.PatientId == id).SingleOrDefault();
            return Ok(clinic);
        }

        // POST api/<ClinicController>
        [HttpPost]
        public IActionResult Post([FromBody] Patient value)
        {
            _context.Patients.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<ClinicController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Patient value)
        {
            var patient = _context.Patients.Where(p => p.PatientId == id).SingleOrDefault();
            if (patient == null)
            {
                return NotFound("Requested record not found.");
            }
            patient.PatientFirstName = value.PatientFirstName;
            patient.PatientLastName = value.PatientLastName;
            patient.PatientDOB = value.PatientDOB;
            patient.PatientHaveIEP = value.PatientHaveIEP;
            patient.PatientInABA = value.PatientInABA;
            patient.PatientClass = value.PatientClass;
            patient.PatientNotes = value.PatientNotes;
            patient.PatientInactive = value.PatientInactive;

            _context.Patients.Update(patient);
            _context.SaveChanges();
            return StatusCode(201, patient);
        }

        // DELETE api/<ClinicController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var patient = _context.Patients.Where(p => p.PatientId == id).SingleOrDefault();
            if (patient == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Patients.Remove(patient);
            _context.SaveChanges();
            return StatusCode(204, patient);
        }
    }
}
