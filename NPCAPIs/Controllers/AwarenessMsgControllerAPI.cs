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
    public class AwarenessMsgControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AwarenessMsgControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AwarenessMsgAPI>>> GetMessages()
        {
            var messages = await _context.AwarenessMsg
                .Where(m => m.IsActive == 1)
                .Select(m => new
                {
                    m.MsgId,
                    m.MsgText,
                    m.OrderView
                  
                })
                .ToListAsync();

            return Ok(messages);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<AwarenessMsgAPI>> GetById([FromQuery] decimal id)
        {
            var message = await _context.AwarenessMsg
                .Where(m => m.IsActive == 1 && m.MsgId == id)
                .Select(m => new
                {
                    m.MsgId,
                    m.MsgText,
                    m.OrderView
                   
                })
                .FirstOrDefaultAsync();

            if (message == null)
            {
                return NotFound(new { message = "Message not found." });
            }

            return Ok(message);
        }
    }
}
