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
    public class SuppliesController : ControllerBase
    {
        private readonly DataContext _context;

        public SuppliesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Supplies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSupply()
        {
          if (_context.Supply == null)
          {
              return NotFound();
          }
            return await _context.Supply.Include(i => i.Storages).ThenInclude(p => p.Product).ToListAsync();
        }

        // GET: api/Supplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply>> GetSupply(int id)
        {
          if (_context.Supply == null)
          {
              return NotFound();
          }
            var supply = await _context.Supply.Include(i => i.Storages).ThenInclude(p => p.Product).FirstOrDefaultAsync(i => i.SupplyID == id);

            if (supply == null)
            {
                return NotFound();
            }

            return supply;
        }

        // PUT: api/Supplies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply(int id, Supply supply)
        {
            if (id != supply.SupplyID)
            {
                return BadRequest();
            }

            _context.Entry(supply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyExists(id))
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

        // POST: api/Supplies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supply>> PostSupply(Supply supply)
        {
          if (_context.Supply == null)
          {
              return Problem("Entity set 'DataContext.Supply'  is null.");
          }
            _context.Supply.Add(supply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupply", new { id = supply.SupplyID }, supply);
        }

        // DELETE: api/Supplies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply(int id)
        {
            if (_context.Supply == null)
            {
                return NotFound();
            }
            var supply = await _context.Supply.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }

            _context.Supply.Remove(supply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplyExists(int id)
        {
            return (_context.Supply?.Any(e => e.SupplyID == id)).GetValueOrDefault();
        }
    }
}
