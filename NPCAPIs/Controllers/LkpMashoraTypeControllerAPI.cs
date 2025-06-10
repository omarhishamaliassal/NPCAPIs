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
    public class LkpMashoraTypeControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LkpMashoraTypeControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LkpMashoraTypeAPI>>> GetMashoraTypes()
        {
            var mashoras = await _context.LkpMashoraType
                .Where(m => m.IsActive == 1)
                .Select(m => new
                {
                    m.MashoraId,
                    m.MashoraDesc,
                  
                })
                .ToListAsync();

            return Ok(mashoras);
        }

       
        [HttpGet("GetById")]
        public async Task<ActionResult<LkpMashoraTypeAPI>> GetById([FromQuery] decimal id)
        {
            var mashora = await _context.LkpMashoraType
                .Where(m => m.IsActive == 1 && m.MashoraId == id)
                .Select(m => new
                {
                    m.MashoraId,
                    m.MashoraDesc,
                    
                })
                .FirstOrDefaultAsync();

            if (mashora == null)
            {
                return NotFound(new { message = "Record not found." });
            }

            return Ok(mashora);
        }
    }
}
