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
    public class ImportantLinksControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImportantLinksControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImportantLinksAPI>>> GetLinks()
        {
            var links = await _context.ImportantLinks
                .Where(l => l.IsActive == 1)
                .Select(l => new
                {
                    l.LinkId,
                    l.LinkName,
                    l.LinkURL,
                    l.LinkImage,
                    l.LinkOrder
                    
                })
                .ToListAsync();

            return Ok(links);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<ImportantLinksAPI>> GetById([FromQuery] decimal id)
        {
            var link = await _context.ImportantLinks
                .Where(l => l.IsActive == 1 && l.LinkId == id)
                .Select(l => new
                {
                    l.LinkId,
                    l.LinkName,
                    l.LinkURL,
                    l.LinkImage,
                    l.LinkOrder
                    
                })
                .FirstOrDefaultAsync();

            if (link == null)
            {
                return NotFound(new { message = "Link not found." });
            }

            return Ok(link);
        }
    }
}
