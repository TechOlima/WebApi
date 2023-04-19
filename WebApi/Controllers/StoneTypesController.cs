using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Classes;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoneTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public StoneTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/StoneTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoneType>>> GetStoneType()
        {
          if (_context.StoneType == null)
          {
              return NotFound();
          }
            return await _context.StoneType.ToListAsync();
        }

        // GET: api/StoneTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoneType>> GetStoneType(int id)
        {
          if (_context.StoneType == null)
          {
              return NotFound();
          }
            var stoneType = await _context.StoneType.FindAsync(id);

            if (stoneType == null)
            {
                return NotFound();
            }

            return stoneType;
        }

        // PUT: api/StoneTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoneType(int id, StoneType stoneType)
        {
            if (id != stoneType.StoneTypeID)
            {
                return BadRequest();
            }

            _context.Entry(stoneType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoneTypeExists(id))
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

        // POST: api/StoneTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StoneType>> PostStoneType(StoneType stoneType)
        {
          if (_context.StoneType == null)
          {
              return Problem("Entity set 'DataContext.StoneType'  is null.");
          }
            _context.StoneType.Add(stoneType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStoneType", new { id = stoneType.StoneTypeID }, stoneType);
        }

        // DELETE: api/StoneTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStoneType(int id)
        {
            if (_context.StoneType == null)
            {
                return NotFound();
            }
            var stoneType = await _context.StoneType.FindAsync(id);
            if (stoneType == null)
            {
                return NotFound();
            }

            _context.StoneType.Remove(stoneType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StoneTypeExists(int id)
        {
            return (_context.StoneType?.Any(e => e.StoneTypeID == id)).GetValueOrDefault();
        }
    }
}
