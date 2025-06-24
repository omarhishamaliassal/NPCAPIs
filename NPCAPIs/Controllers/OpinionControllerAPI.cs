using Microsoft.AspNetCore.Mvc;
using NPCAPIs.Models;
using NPCAPIs.Data; 
using System.Threading.Tasks;

namespace NPCAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpinionControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OpinionControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

       
        [HttpPost("Add")]
        public async Task<IActionResult> AddOpinion([FromBody] OpinionAPI opinion)
        {
            if (opinion == null)
                return BadRequest(new { message = "❌ البيانات غير صالحة." });

            try
            {
                _context.Opinion.Add(opinion);
                await _context.SaveChangesAsync();

                return Ok(new { message = "✅ تم إرسال الرأي بنجاح", opinion.OpinionId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "❌ حصل خطأ أثناء حفظ الرأي", error = ex.Message });
            }
        }
    }
}
