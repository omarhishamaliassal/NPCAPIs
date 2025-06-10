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
    public class AboutControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AboutControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

     
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AboutAPI>>> GetAbout()
        {
            var about = await _context.About.ToListAsync();
            return Ok(about);
        }

        
        [HttpGet("GetById")]
        public async Task<ActionResult<AboutAPI>> GetById([FromQuery] int id)
        {
            var aboutItem = await _context.About
                .FirstOrDefaultAsync(a => a.AboutId == id);

            if (aboutItem == null)
            {
                return NotFound(new { message = "About item not found." });
            }

            return Ok(aboutItem);
        }
    }
}
