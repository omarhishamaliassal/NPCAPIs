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
    public class InfographControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InfographControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InfographAPI>>> GetInfographs()
        {
            var infographs = await _context.Infograph
                .Where(i => i.IsActive == 1)
                .Select(i => new
                {
                    i.InfoId,
                    i.InfoTitle,
                    i.InfoDesc,
                    i.InfoPhoto,
                    i.PublicationDate,
                    i.OrderView,
                    i.URLink,
                    i.OnMainPage
                    
                })
                .ToListAsync();

            return Ok(infographs);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<InfographAPI>> GetById([FromQuery] decimal id)
        {
            var infograph = await _context.Infograph
                .Where(i => i.IsActive == 1 && i.InfoId == id)
                .Select(i => new
                {
                    i.InfoId,
                    i.InfoTitle,
                    i.InfoDesc,
                    i.InfoPhoto,
                    i.PublicationDate,
                    i.OrderView,
                    i.URLink,
                    i.OnMainPage
                    
                })
                .FirstOrDefaultAsync();

            if (infograph == null)
            {
                return NotFound(new { message = "Infograph not found." });
            }

            return Ok(infograph);
        }
    }
}
