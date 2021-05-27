using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceOfServiceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PlaceOfServiceController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL PlacesOfService *****
        // <baseurl>/api/placeofservice
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var placesOfService = _context.PlacesOfServices.ToList();
            if (placesOfService == null)
            {
                return NotFound();
            }
            return Ok(placesOfService);
        }
        // ***** GET A PlaceOfService by ID *****
        // <baseurl>/api/placeofservice
        [HttpGet("{code}"), Authorize]
        public IActionResult GetById(string code)
        {
            var placeOfService = _context.PlacesOfServices.Where(p => p.PlaceOfServiceCode == code).SingleOrDefault();
            return Ok(placeOfService);
        }
        // ***** ADD A PlaceOfService *****
        // POST /api/placeofservice
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] PlaceOfService value)
        {
            _context.PlacesOfServices.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A PlaceOfService *****
        // PUT /api/placeofservice
        [HttpPut("{code}"), Authorize]
        public IActionResult Put(string code, [FromBody] PlaceOfService value)
        {
            var placeOfService = _context.PlacesOfServices.Where(p => p.PlaceOfServiceCode == code).SingleOrDefault();
            if (placeOfService == null)
            {
                return NotFound("Requested record not found.");
            }
            placeOfService.PlaceOfServiceDesc = value.PlaceOfServiceDesc;

            _context.PlacesOfServices.Update(placeOfService);
            _context.SaveChanges();
            return StatusCode(201, placeOfService);
        }


        // ***** DELETE A PlaceOfService *****
        // DELETE /api/placeofservice
        [HttpDelete("{code}"), Authorize]
        public IActionResult Delete(string code)
        {

            var placeOfService = _context.PlacesOfServices.Where(p => p.PlaceOfServiceCode == code).SingleOrDefault();
            if (placeOfService == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.PlacesOfServices.Remove(placeOfService);
            _context.SaveChanges();
            return StatusCode(204, placeOfService);
        }
    }
}
