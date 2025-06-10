using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPCAPIs.Data;
using NPCAPIs.Models;

[Route("api/[controller]")]
[ApiController]
public class VServicesControllerAPI : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public VServicesControllerAPI(ApplicationDbContext context)
    {
        _context = context;
    }

   
    [HttpGet]
    public async Task<ActionResult<IEnumerable<VServicesAPI>>> GetVServices()
    {
        var services = await _context.VServices.ToListAsync();
        return Ok(services);
    }

    [HttpGet("GetById")]
    public async Task<ActionResult<IEnumerable<VServicesAPI>>> GetById([FromQuery] decimal id)
    {
        var services = await _context.VServices
            .Where(s => s.MashoraId == id)
            .ToListAsync();

        if (services == null || services.Count == 0)
        {
            return NotFound(new { message = "No records found for this ID." });
        }

        return Ok(services);
    }

}
