using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Classes;
using WebApi.Classes.Operations;

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
        public async Task<ActionResult<IEnumerable<SupplyGet>>> GetSupply(DateTime? dateFrom, DateTime? dateTo)
        {
          if (_context.Supply == null)
          {
              return NotFound();
          }
            return await _context.Supply
                .Include(i => i.Storages).ThenInclude(p => p.Product)
                .Where(i=>
                (dateFrom > DateTime.MinValue && dateTo > DateTime.MinValue && i.ReceivingDate > dateFrom && i.ReceivingDate < dateTo) ||
                (dateFrom > DateTime.MinValue && dateTo == DateTime.MinValue && i.ReceivingDate > dateFrom) ||
                (dateFrom == DateTime.MinValue && dateTo > DateTime.MinValue && i.ReceivingDate < dateTo) ||
                (dateFrom == DateTime.MinValue && dateTo == DateTime.MinValue) ||
                (dateFrom == null && dateTo == null)
                 )
                .Select(i => new SupplyGet(i))
                .ToListAsync();
        }

        // GET: api/Supplies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplyGet>> GetSupply(int id)
        {
          if (_context.Supply == null)
          {
              return NotFound();
          }
            var supply = await _context.Supply
                .Include(i => i.Storages).ThenInclude(p => p.Product)
                .Where(i => i.SupplyID == id)
                .Select(i=> new SupplyGet(i))
                .FirstOrDefaultAsync();

            if (supply == null)
            {
                return NotFound();
            }

            return supply;
        }

        // PUT: api/Supplies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply(int id, SupplyPut supplyPut)
        {
            Supply supply = new Supply(supplyPut);

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
        public async Task<ActionResult<Supply>> PostSupply(SupplyPost supplyPost)
        {

          if (_context.Supply == null)
          {
              return Problem("Entity set 'DataContext.Supply'  is null.");
          }
            Supply supply = new Supply(supplyPost);
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
            //удаляем связанных товары на складе
            Storage[] storages = _context.Storage.Where(i => i.SupplyID == supply.SupplyID).ToArray();            

            _context.Storage.RemoveRange(storages);
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
