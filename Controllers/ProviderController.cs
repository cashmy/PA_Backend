using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Collections.Generic;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProviderController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ProviderController>
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var providers = _context.Providers.ToList();
            if (providers == null)
            {
                return NotFound();
            }
            return Ok(providers);
        }

        // GET api/<ProviderController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var provider = _context.Providers.Where(p => p.ProviderId == id).SingleOrDefault();
            return Ok(provider);
        }

        // POST api/<ProviderController>
        [HttpPost]
        public IActionResult Post([FromBody] Provider value)
        {
            if (value.AssignedStaffUserId == "")
            {
                value.AssignedStaffUserId = null;

            }
            _context.Providers.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT api/<ProviderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Provider value)
        {
            var provider = _context.Providers.Where(c => c.ProviderId == id).SingleOrDefault();
            if (provider == null)
            {
                return NotFound("Requested record not found.");
            }

            provider.ProviderFirstName = value.ProviderFirstName;
            provider.ProviderLastName = value.ProviderLastName;
            provider.ProviderEmail = value.ProviderEmail;
            provider.ProviderUserId = value.ProviderUserId;
            provider.ProviderPhone = value.ProviderPhone;
            provider.ProviderRcvEmails = value.ProviderRcvEmails;
            provider.ProviderRcvNotifications = value.ProviderRcvNotifications;
            provider.ProviderNPI = value.ProviderNPI;
            provider.ProviderTaxonomy = value.ProviderTaxonomy;
            provider.ProviderNotes = value.ProviderNotes;
            provider.AssignedStaffUserId = value.AssignedStaffUserId;
            provider.ProviderInactive = value.ProviderInactive;

            _context.Providers.Update(provider);
            _context.SaveChanges();
            return StatusCode(201, provider);
        }

        // DELETE api/<ProviderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var provider = _context.Providers.Where(p => p.ProviderId == id).SingleOrDefault();
            if (provider == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Providers.Remove(provider);
            _context.SaveChanges();
            return StatusCode(204, provider);
        }
    }
}
