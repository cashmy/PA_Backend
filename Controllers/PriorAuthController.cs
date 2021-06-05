using PA_Backend.Data;
using PA_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace PA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorAuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PriorAuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        // ***** GET ALL PriorAuths *****
        // <baseurl>/api/priorAuth
        [HttpGet, Authorize]
        public IActionResult Get()
        {
            var priorAuths = _context.PriorAuths.ToList();
            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }

        // ***** GET ALL PriorAuths by Archive Status *****
        // <baseurl>/api/priorAuth/archive
        [HttpGet("archive/{archiveSts}"), Authorize]
        public IActionResult GetByArchiveSts(bool archiveSts)
        {
            var priorAuths = _context.PriorAuths
                .Where(pa => pa.PAArchived == archiveSts)
                .Include(pa => pa.Patient)
                .Include(pa => pa.Carrier)
                .Include(pa => pa.Provider)
                .Include(pa => pa.Status)
                .ToList();
            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }

        // ***********  PRIOR AUTH VIEWS **********
        // ***** GET ALL PriorAuths by Therapist and Archive Status *****
        // <baseurl>/api/priorAuth/provider
        [HttpGet("provider/{Id}/{archiveSts}"), Authorize]
        public IActionResult GetByProvider(int id, bool archiveSts)
        {
            var priorAuths = _context.PriorAuths.Where(pa => pa.PAProviderId == id && pa.PAArchived == archiveSts).ToList();
            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }
        // ***** GET ALL PriorAuths by Carrier and Archive Status *****
        // <baseurl>/api/priorAuth/carrier
        [HttpGet("carrier/{Id}/{archiveSts}"), Authorize]
        public IActionResult GetByCarrier(int id, bool archiveSts)
        {
            var priorAuths = _context.PriorAuths.Where(pa => pa.PACarrierId == id && pa.PAArchived == archiveSts).ToList();
            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }
        // ***** GET ALL PriorAuths by AssignedStaff and Archive Status *****
        // <baseurl>/api/priorAuth/staff
        [HttpGet("staff/{archiveSts}"), Authorize]
        public IActionResult GetByStaffMember(bool archiveSts)
        {
            var userId = User.FindFirstValue("id");
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var priorAuths = _context.PriorAuths.Where(pa => pa.PAAssignedStaff == userId && pa.PAArchived == archiveSts).ToList();
            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }
        // ***** GET ALL PriorAuths for a Patient *****
        // <baseurl>/api/priorAuth/patient
        [HttpGet("patient/{id}"), Authorize]
        public IActionResult GetByCarrier(int id)
        {
            var priorAuths = _context.PriorAuths.Where(pa => pa.PAPatientId == id).ToList();
            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }
        // ***** GET ALL PriorAuths for a Status and Archived Status *****
        // <baseurl>/api/priorAuth/status
        [HttpGet("status/{id}/archive/{archiveSts}"), Authorize]
        public IActionResult GetByStatus(int id, bool archiveSts)
        {
            var priorAuths = _context.PriorAuths
                .Where(pa => pa.PAStatus == id && pa.PAArchived == archiveSts)
                .Include(pa => pa.Patient)
                .Include(pa => pa.Carrier)
                .Include(pa => pa.Provider)
                .ToList();
            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }
        // ***** GET COUNT for a Given Status: Active Only *****
        // <baseurl>/api/priorAuth/count
        [HttpGet("count/{id}"), Authorize]
        public IActionResult GetCountByStatus(int id)
        {
            var priorAuths = _context.PriorAuths
                .Where(pa => pa.PAStatus == id && pa.PAArchived == false)
                .GroupBy(pa => pa.PAStatus)
                .Select(pa => new { Count = pa.Count() });

            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }


        // ***** GET NON-APPROVED COUNTs for All Providers: Active Only *****
        // <baseurl>/api/priorAuth/provcount
        [HttpGet("provcount"), Authorize]
        public IActionResult GetNonApprvdCountForProviders()
        {
            var approved = 1;
            // StatusId value of 1 == Approved 
            var priorAuths = _context.PriorAuths
                .Where(pa => pa.PAArchived == false && pa.PAStatus != approved)
                .Include(pa => pa.Status)
                .GroupBy(pa => new { pa.PAProviderId })
                .Select(pa => new {pa.Key.PAProviderId, Count = pa.Count() })
                .Join(_context.Providers,
                    a => a.PAProviderId,
                    b => b.ProviderId,
                    (a, b) => new { a.PAProviderId, b.ProviderFirstName, b.ProviderLastName, a.Count })
                .ToList();

            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }

        // ***** GET COUNTs for All Providers: Active Only *****
        // <baseurl>/api/priorAuth/provcount
        [HttpGet("provallcounts"), Authorize]
        public IActionResult GetCountsForProviders()
        {
            var priorAuths = _context.PriorAuths
                .Where(pa => pa.PAArchived == false)
                .Include(pa => pa.Status)
                .GroupBy(pa => new { pa.PAProviderId, pa.PAStatus } )
                .OrderBy(pa => pa.Key.PAProviderId)
                .ThenBy(pa => pa.Key.PAStatus )
                .Select(pa => new {pa.Key.PAProviderId, pa.Key.PAStatus, Count = pa.Count() })
                .Join(_context.Providers, 
                    a => a.PAProviderId, 
                    b => b.ProviderId, 
                    (a, b) => new {a.PAProviderId, b.ProviderFirstName, b.ProviderLastName, a.PAStatus, a.Count})
                .Join(_context.Statuses,
                    a => a.PAStatus,
                    b => b.StatusId,
                    (a, b) => new { a.PAProviderId, a.ProviderFirstName, a.ProviderLastName, a.PAStatus, 
                                    b.StatusName, b.DisplayOnSummary, b.StatusColor, b.StatusTextColor, a.Count, }
                )
                .ToList();

            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }

        // ***** GET NON-APPROVED COUNTs for All Carriers: Active Only *****
        // <baseurl>/api/priorAuth/provcount
        [HttpGet("carrcount"), Authorize]
        public IActionResult GetNonApprvdCountForCarriers()
        {
            var approved = 1;
            // StatusId value of 1 == Approved 
            var priorAuths = _context.PriorAuths
                .Where(pa => pa.PAArchived == false && pa.PAStatus != approved)
                .Include(pa => pa.Status)
                .GroupBy(pa => new { pa.PACarrierId })
                .Select(pa => new { pa.Key.PACarrierId, Count = pa.Count() })
                .Join(_context.Carriers,
                    a => a.PACarrierId,
                    b => b.CarrierId,
                    (a, b) => new { a.PACarrierId, b.CarrierName, b.CarrierShortName, a.Count })
                .ToList();

            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }

        // ***** GET COUNT for a Given Caarrier *****
        // <baseurl>/api/priorAuth/count
        [HttpGet("carrcount/{id}"), Authorize]
        public IActionResult GetCountsByCarrier(int id)
        {
            var priorAuths = _context.PriorAuths
                .Where(pa => pa.PACarrierId == id)
                .OrderBy(pa => pa.Status )
                .Include(pa => pa.Status )
                .GroupBy(pa => new { pa.PACarrierId, pa.PAStatus })
                .Select(pa => new {pa.Key.PACarrierId, pa.Key.PAStatus, Count = pa.Count() })
                .Join(_context.Carriers,
                    a => a.PACarrierId,
                    b => b.CarrierId,
                    (a, b) => new { a.PACarrierId, b.CarrierName, b.CarrierShortName, a.PAStatus, a.Count })
                 .Join(_context.Statuses,
                    a => a.PAStatus,
                    b => b.StatusId,
                    (a, b) => new { a.PACarrierId, a.CarrierName, a.CarrierShortName, a.PAStatus, 
                                    b.StatusName, b.DisplayOnSummary, b.StatusColor, b.StatusTextColor, a.Count, }
                )
                .ToList();

            if (priorAuths == null)
            {
                return NotFound();
            }
            return Ok(priorAuths);
        }


        // **********

        // ***** GET A PriorAuth by ID *****
        // <baseurl>/api/priorAuth
        [HttpGet("{id}"), Authorize]
        public IActionResult GetById(int id)
        {
            var priorAuth = _context.PriorAuths.Where(p => p.Id == id).SingleOrDefault();
            return Ok(priorAuth);
        }
        

        // *** GET A PriorAuth by ID will all INCLUDES
        // <baseurl>/api/priorAuth/joins/
        [HttpGet("joins/{id}"), Authorize]
        public IActionResult GetByIdJoined(int id)
        {
            var priorAuth = _context.PriorAuths
                .Where(p => p.Id == id)
                .Include(p => p.Patient)
                .Include(p => p.Carrier)
                .Include(p => p.Status)
                .Include(p => p.Treatment)
                .Include(p => p.PlaceOfService)
                .Include(p => p.Provider)
                .Include(p => p.StaffMember)
                .SingleOrDefault();
            
            return Ok(priorAuth);
        }

        // ***** ADD A PriorAuth *****
        // POST /api/priorAuth
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] PriorAuth value)
        {
            _context.PriorAuths.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A PriorAuth *****
        // PUT /api/priorAuth
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] PriorAuth value)
        {
            var priorAuth = _context.PriorAuths.Where(p => p.Id == id).SingleOrDefault();
            if (priorAuth == null)
            {
                return NotFound("Requested record not found.");
            }
            // Foreign Keys Fields 
            priorAuth.PAPatientId = value.PAPatientId;
            priorAuth.PACarrierId = value.PACarrierId;
            priorAuth.PAStatus = value.PAStatus;
            priorAuth.PATreatmentCode = value.PATreatmentCode;
            priorAuth.PAServiceCode = value.PAServiceCode;
            priorAuth.PAProviderId = value.PAProviderId;
            priorAuth.PAAssignedStaff = value.PAAssignedStaff;
            priorAuth.PAClinicId = value.PAClinicId;

            // Data Fields
            priorAuth.PARequestDate = value.PARequestDate;
            priorAuth.PALastEvalDate = value.PALastEvalDate;
            priorAuth.PALastPOCDate = value.PALastPOCDate;
            priorAuth.PAVisitFrequency = value.PAVisitFrequency;
            priorAuth.PARqstNmbrVisits = value.PARqstNmbrVisits;
            priorAuth.PAStartDate = value.PAStartDate;
            priorAuth.PAExpireDate = value.PAExpireDate;
            priorAuth.PAArchived = value.PAArchived;

            _context.PriorAuths.Update(priorAuth);
            _context.SaveChanges();
            return StatusCode(201, priorAuth);
        }


        // ***** DELETE A PriorAuth *****
        // DELETE /api/priorAuth
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {

            var priorAuth = _context.PriorAuths.Where(p => p.Id == id).SingleOrDefault();
            if (priorAuth == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.PriorAuths.Remove(priorAuth);
            _context.SaveChanges();
            return StatusCode(204, priorAuth);
        }
    }
}
