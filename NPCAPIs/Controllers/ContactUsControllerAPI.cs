using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPCAPIs.Data;
using NPCAPIs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPCAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactUsControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactUsAPI>>> GetContactInfo()
        {
            var contactList = await _context.ContactUs
                .Select(c => new
                {
                    c.CUId,
                    c.MobileNum,
                    c.Address,
                    c.Email,
                    c.Location
                })
                .ToListAsync();

            return Ok(contactList);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ContactUsAPI>> GetById([FromQuery] decimal id)
        {
            var contact = await _context.ContactUs
                .Where(c => c.CUId == id)
                .Select(c => new
                {
                    c.CUId,
                    c.MobileNum,
                    c.Address,
                    c.Email,
                    c.Location
                })
                .FirstOrDefaultAsync();

            if (contact == null)
                return NotFound(new { message = "Contact item not found." });

            return Ok(contact);
        }
    }
}
