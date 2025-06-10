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
    public class VPhotoesControllerAPI : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VPhotoesControllerAPI(ApplicationDbContext context)
        {
            _context = context;
        }

 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VPhotoesAPI>>> GetVPhotoes()
        {
            var photos = await _context.VPhotoes
                .AsNoTracking()
                .Where(p => p.IsActive == 1)
                .Select(p => new
                {
                    p.AlbumId,
                    p.PhotoId,
                    p.AlbumTitle,
                    p.PublishDate,
                    p.PhotoTitle,
                    p.Photo,
                    p.OrderView
                    
                })
                .ToListAsync();

            return Ok(photos);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<IEnumerable<VPhotoesAPI>>> GetById([FromQuery] decimal albumId)
        {
            var photosInAlbum = await _context.VPhotoes
                .AsNoTracking()
                .Where(p => p.IsActive == 1 && p.AlbumId == albumId)
                .Select(p => new
                {
                    p.AlbumId,
                    p.PhotoId,
                    p.AlbumTitle,
                    p.PublishDate,
                    p.PhotoTitle,
                    p.Photo,
                    p.OrderView
            
                })
                .ToListAsync();

            if (photosInAlbum == null || photosInAlbum.Count == 0)
            {
                return NotFound(new { message = "No photos found for this album." });
            }

            return Ok(photosInAlbum);
        }
    }
}
