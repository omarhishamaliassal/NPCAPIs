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
    public class CommonQuestionControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommonQuestionControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommonQuestionAPI>>> GetQuestions()
        {
            var questions = await _context.CommonQuestion
                .Where(q => q.IsActive == 1)
                .Select(q => new
                {
                    q.QId,
                    q.Quest,
                    q.Answer
                })
                .ToListAsync();

            return Ok(questions);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<CommonQuestionAPI>> GetById([FromQuery] decimal id)
        {
            var question = await _context.CommonQuestion
                .Where(q => q.IsActive == 1 && q.QId == id)
                .Select(q => new
                {
                    q.QId,
                    q.Quest,
                    q.Answer
                })
                .FirstOrDefaultAsync();

            if (question == null)
                return NotFound(new { message = "Question not found." });

            return Ok(question);
        }
    }
}
