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
    public class GenderTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public GenderTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GenderTypes
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GenderType>>> GetGenderType()
        {
          if (_context.GenderType == null)
          {
              return NotFound();
          }
            return await _context.GenderType.ToListAsync();
        }

        // GET: api/GenderTypes/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<GenderType>> GetGenderType(int id)
        {
          if (_context.GenderType == null)
          {
              return NotFound();
          }
            var genderType = await _context.GenderType.FindAsync(id);

            if (genderType == null)
            {
                return NotFound();
            }

            return genderType;
        }

        // PUT: api/GenderTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenderType(int id, GenderType genderType)
        {
            if (id != genderType.GenderTypeID)
            {
                return BadRequest();
            }

            _context.Entry(genderType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenderTypeExists(id))
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

        // POST: api/GenderTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenderType>> PostGenderType(GenderType genderType)
        {
          if (_context.GenderType == null)
          {
              return Problem("Entity set 'DataContext.GenderType'  is null.");
          }
            _context.GenderType.Add(genderType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenderType", new { id = genderType.GenderTypeID }, genderType);
        }

        // DELETE: api/GenderTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenderType(int id)
        {
            if (_context.GenderType == null)
            {
                return NotFound();
            }
            var genderType = await _context.GenderType.FindAsync(id);
            if (genderType == null)
            {
                return NotFound();
            }

            _context.GenderType.Remove(genderType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenderTypeExists(int id)
        {
            return (_context.GenderType?.Any(e => e.GenderTypeID == id)).GetValueOrDefault();
        }
    }
}
