using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPCAPIs.Data;
using NPCAPIs.Models;

[Route("api/[controller]")]
[ApiController]
public class VIndicatorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VIndicatorsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<VIndicatorsAPI>>> GetVIndocators()
        {
            var indicators = await _context.VIndicators.ToListAsync();
            return Ok(indicators);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IEnumerable<VIndicatorsAPI>>> GetById([FromQuery] decimal id)
        {
            var indicators = await _context.VIndicators
                .Where(s => s.IndId == id)
                .ToListAsync();

            if (indicators == null || indicators.Count == 0)
            {
                return NotFound(new { message = "No records found for this ID." });
            }

            return Ok(indicators);
        }

    }
