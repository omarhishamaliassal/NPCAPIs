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
    public class TeamMembersControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeamMembersControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        // POST: api/TeamMembers
        [HttpPost]
        public async Task<IActionResult> CreateTeamMember([FromBody] TeamMemberCreateDto dto)
        {
            // Validate Qualification exists
            var qualification = await _context.LkpQualifications
                .FirstOrDefaultAsync(q => q.QualificationId == dto.QualificationId);

            if (qualification == null)
                return BadRequest("Invalid QualificationId");

            var teamMember = new TeamMember
            {
                MemberName = dto.MemberName,
                MobileNum = dto.MobileNum,
                EMail = dto.EMail,
                QualificationId = dto.QualificationId,
                CurrentJob = dto.CurrentJob,
                EntryDate = dto.EntryDate
            };

            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeamMemberById),
                new { id = teamMember.TeamMemberId }, teamMember);
        }

        // GET: api/TeamMembers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamMemberById(decimal id)
        {
            var teamMember = await _context.TeamMembers
                .Include(tm => tm.Qualification)
                .FirstOrDefaultAsync(tm => tm.TeamMemberId == id);

            if (teamMember == null)
                return NotFound();

            return Ok(teamMember);
        }
    }
}
