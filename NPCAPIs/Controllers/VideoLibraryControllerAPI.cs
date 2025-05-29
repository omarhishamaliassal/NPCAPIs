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
    public class VideoLibraryControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VideoLibraryControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoLibraryAPI>>> GetVideos()
        {
            var videos = await _context.VideoLibrary
                .Where(v => v.IsActive == 1)
                .Select(v => new
                {
                    v.VedioId,
                    v.VedioTitle,
                    v.PublishDate,
                    v.VCoverPhoto,
                    v.VedioURL,
                    v.OnMainPage
                    
                })
                .ToListAsync();

            return Ok(videos);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<VideoLibraryAPI>> GetById([FromQuery] decimal id)
        {
            var video = await _context.VideoLibrary
                .Where(v => v.IsActive == 1 && v.VedioId == id)
                .Select(v => new
                {
                    v.VedioId,
                    v.VedioTitle,
                    v.PublishDate,
                    v.VCoverPhoto,
                    v.VedioURL,
                    v.OnMainPage
                    
                })
                .FirstOrDefaultAsync();

            if (video == null)
            {
                return NotFound(new { message = "Video not found." });
            }

            return Ok(video);
        }
    }
}
