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
    public class VActiveEmpControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VActiveEmpControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VActiveEmpAPI>>> GetVActiveEmps()
        {
            var emps = await _context.VActiveEmp.ToListAsync();
            return Ok(emps);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<VActiveEmpAPI>> GetById([FromQuery] decimal id)
        {
            var emp = await _context.VActiveEmp.FirstOrDefaultAsync(v => v.GovId == id);

            if (emp == null)
            {
                return NotFound(new { message = "Employee record not found." });
            }

            return Ok(emp);
        }
    }
}
