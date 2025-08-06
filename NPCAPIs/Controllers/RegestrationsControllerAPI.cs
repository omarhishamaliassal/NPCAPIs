using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPCAPIs.Data;
using NPCAPIs.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPCAPIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegestrationsControllerAPI : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegestrationsControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/TeamMembers
        [HttpPost]
        public async Task<IActionResult> CreateTeamMember([FromBody] RegestrationCreateDto dto)
        {
            // ✅ تحقق من وجود Qualification
            var qualification = await _context.LkpQualifications
                .FirstOrDefaultAsync(q => q.QualificationId == dto.QualificationId);

            if (qualification == null)
                return BadRequest("Invalid QualificationId");

            // ✅ تحقق من تكرار البيانات
            if (await _context.Regestrations.AnyAsync(r => r.UserName == dto.UserName))
                return BadRequest("Username already exists");

            if (await _context.Regestrations.AnyAsync(r => r.EMail == dto.EMail))
                return BadRequest("Email already exists");

            if (await _context.Regestrations.AnyAsync(r => r.MobileNum == dto.MobileNum))
                return BadRequest("Mobile number already exists");

            // ✅ إنشاء السجل
            var regestrations = new Regestration
            {
                RegName = dto.RegName,
                MobileNum = dto.MobileNum,
                EMail = dto.EMail,
                QualificationId = dto.QualificationId,
                CurrentJob = dto.CurrentJob,
                UserName = dto.UserName,
                Password = dto.Password,
                EntryDate = dto.EntryDate
            };

            _context.Regestrations.Add(regestrations);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegesterById),
                new { id = regestrations.RegesterId }, regestrations);
        }


        // GET: api/TeamMembers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegesterById(decimal id)
        {
            var regestrations = await _context.Regestrations
                .Include(tm => tm.Qualification)
                .FirstOrDefaultAsync(tm => tm.RegesterId == id);

            if (regestrations == null)
                return NotFound();

            return Ok(regestrations);
        }
    }
}
