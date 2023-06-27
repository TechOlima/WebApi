using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Classes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhotosController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public PhotosController(DataContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // Post: api/Photos/UploadImage
        /*
        [HttpPost]
        public async Task<ActionResult<Photo>> PostPhoto([FromForm] int productID, [FromForm] IFormFile uploadedFile)
        {
            Photo photo = new Photo() { ProductID = productID };
            _context.Photo.Add(photo);
            await _context.SaveChangesAsync();

            if (uploadedFile != null)
            {
                string content_path = photo.PhotoID.ToString() + "_" + uploadedFile.FileName;
                string path = "/images/" + content_path;
                using (var fileStream = new FileStream(_appEnvironment.ContentRootPath + path, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }                
                photo.photoUrl = content_path;
                await _context.SaveChangesAsync();
                
            }
            return CreatedAtAction("GetPhoto", new { id = photo.PhotoID }, photo);
        }
        */

        // GET: api/Photos
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Photo>>> GetPhoto()
        {
            if (_context.Photo == null)
          {
              return NotFound();
          }
            return await _context.Photo.ToListAsync();
        }

        // GET: api/Photos/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Photo>> GetPhoto(int id)
        {
          if (_context.Photo == null)
          {
              return NotFound();
          }
            var photo = await _context.Photo.FirstOrDefaultAsync(i => i.PhotoID == id); ;

            if (photo == null)
            {
                return NotFound();
            }

            return photo;
        }

        // PUT: api/Photos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoto(int id, Photo photo)
        {
            if (id != photo.PhotoID)
            {
                return BadRequest();
            }

            _context.Entry(photo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhotoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Photos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        
        [HttpPost]
        public async Task<ActionResult<Photo>> PostPhoto(Photo photo)
        {
          if (_context.Photo == null)
          {
              return Problem("Entity set 'DataContext.Photo'  is null.");
          }
            _context.Photo.Add(photo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoto", new { id = photo.PhotoID }, photo);
        }
        
        // DELETE: api/Photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            if (_context.Photo == null)
            {
                return NotFound();
            }
            var photo = await _context.Photo.FindAsync(id);
            if (photo == null)
            {
                return NotFound();
            }

            _context.Photo.Remove(photo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PhotoExists(int id)
        {
            return (_context.Photo?.Any(e => e.PhotoID == id)).GetValueOrDefault();
        }
    }
}
