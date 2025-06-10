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
    public class InitiativeNumbersControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InitiativeNumbersControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InitiativeNumbersAPI>>> GetInitiatives()
        {
            var initiatives = await _context.InitiativeNumbers
                .Where(i => i.IsActive == 1)
                .Select(i => new
                {
                    i.InitId,
                    i.IndTitle,
                    i.IndNumber,
                    i.IndUnit,
                    i.OnMainPage
                    
                })
                .ToListAsync();

            return Ok(initiatives);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<InitiativeNumbersAPI>> GetById([FromQuery] decimal id)
        {
            var initiative = await _context.InitiativeNumbers
                .Where(i => i.IsActive == 1 && i.InitId == id)
                .Select(i => new
                {
                    i.InitId,
                    i.IndTitle,
                    i.IndNumber,
                    i.IndUnit,
                    i.OnMainPage
                    
                })
                .FirstOrDefaultAsync();

            if (initiative == null)
            {
                return NotFound(new { message = "Initiative number not found." });
            }

            return Ok(initiative);
        }
    }
}
