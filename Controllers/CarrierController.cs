using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CarrierController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL Carriers *****
        // <baseurl>/api/carrier
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var carriers = _context.Carriers.ToList();
            if (carriers == null)
            {
                return NotFound();
            }
            return Ok(carriers);
        }
        // ***** GET A Carrier by ID *****
        // <baseurl>/api/carrier
        [HttpGet("{CarrierId}"), Authorize]
        public IActionResult GetById(int carrierId)
        {
            var carrier = _context.Carriers.Where(p => p.CarrierId == carrierId).SingleOrDefault();
            return Ok(carrier);
        }
        // ***** ADD A Carrier *****
        // POST /api/carrier
        [HttpPost, Authorize]
        public IActionResult Post([FromBody]Carrier value)
        {
            _context.Carriers.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPPDATE A Carrier *****
        // PUT /api/carrier
        [HttpPut("{CarrierId}"), Authorize]
        public IActionResult Put(int carrierId, [FromBody]Carrier value)
        {
            var carrier = _context.Carriers.Where(p => p.CarrierId == carrierId).SingleOrDefault();
            if (carrier == null)
            {
                return NotFound("Requested record not found.");
            }
            carrier.CarrierContactName = value.CarrierName;
            carrier.CarrierShortName = value.CarrierShortName;
            carrier.CarrierContactName = value.CarrierContactName;
            carrier.CarrierContactEmail = value.CarrierContactEmail;
            carrier.CarrierContactPhone = value.CarrierContactPhone;
            carrier.CarrierProviderPhone = value.CarrierProviderPhone;
            carrier.CarrierClass = value.CarrierClass;
            carrier.CarrierNotes = value.CarrierNotes;
            
            _context.Carriers.Update(carrier);
            _context.SaveChanges();
            return StatusCode(201, carrier);
        }


        // ***** DELETE A Carrier *****
        // DELETE /api/carrier
        [HttpDelete("{CarrierId}"), Authorize]
        public IActionResult Delete(int carrierId)
        {

            var carrier = _context.Carriers.Where(p => p.CarrierId == carrierId).SingleOrDefault();
            if (carrier == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Carriers.Remove(carrier);
            _context.SaveChanges();
            return StatusCode(204, carrier);
        }
    }
}

