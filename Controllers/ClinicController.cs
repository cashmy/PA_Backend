using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ClinicController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ClinicController>
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var clinics = _context.Clinics.ToList();
            if (clinics == null)
            {
                return NotFound();
            }
            return Ok(clinics);
        }

        // GET api/<ClinicController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var clinic = _context.Clinics.Where(p => p.ClinicId == id).SingleOrDefault();
            return Ok(clinic);
        }

        // POST api/<ClinicController>
        [HttpPost]
        public IActionResult Post([FromBody]Clinic value)
        {
            _context.Clinics.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<ClinicController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Clinic value)
        {
            var clinic = _context.Clinics.Where(c => c.ClinicId == id).SingleOrDefault();
            if (clinic == null)
            {
                return NotFound("Requested record not found.");
            }
            clinic.ClinicName = value.ClinicName;
            clinic.ClinicAddress1 = value.ClinicAddress1;
            clinic.ClinicAddress2 = value.ClinicAddress2;
            clinic.ClinicCity = value.ClinicCity;
            clinic.ClinicState = value.ClinicState;
            clinic.ClinicZip = value.ClinicZip;
            clinic.ClinicPhone = value.ClinicPhone;
            clinic.ClinicNPI = value.ClinicNPI;
            clinic.ClinicIsAGroup = value.ClinicIsAGroup;

            _context.Clinics.Update(clinic);
            _context.SaveChanges();
            return StatusCode(201, clinic);
        }

        // DELETE api/<ClinicController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var clinic = _context.Clinics.Where(p => p.ClinicId == id).SingleOrDefault();
            if (clinic == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Clinics.Remove(clinic);
            _context.SaveChanges();
            return StatusCode(204, clinic);
        }
    }
}
