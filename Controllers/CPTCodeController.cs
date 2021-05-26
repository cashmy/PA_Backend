using PA_Backend.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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
        // <baseurl>/api/cptcodes
        [HttpGet, Authorize]
        public IActionResult GetCPTCodes()
        {
            var cptCodes = _context.CPTCodes.ToList();

            if (cptCodes == null)
            {
                return NotFound();
            }
            return Ok(cptCodes);
        }
    }
    
}