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
    public class Supply_ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public Supply_ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Supply_Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply_Product>>> GetSupply_Product()
        {
          if (_context.Supply_Product == null)
          {
              return NotFound();
          }
            return await _context.Supply_Product.ToListAsync();
        }

        // GET: api/Supply_Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply_Product>> GetSupply_Product(int id)
        {
          if (_context.Supply_Product == null)
          {
              return NotFound();
          }
            var supply_Product = await _context.Supply_Product.FindAsync(id);

            if (supply_Product == null)
            {
                return NotFound();
            }

            return supply_Product;
        }

        // PUT: api/Supply_Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply_Product(int id, Supply_Product supply_Product)
        {
            if (id != supply_Product.Supply_ProductID)
            {
                return BadRequest();
            }

            _context.Entry(supply_Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Supply_ProductExists(id))
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

        // POST: api/Supply_Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supply_Product>> PostSupply_Product(Supply_Product supply_Product)
        {
          if (_context.Supply_Product == null)
          {
              return Problem("Entity set 'DataContext.Supply_Product'  is null.");
          }
            _context.Supply_Product.Add(supply_Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupply_Product", new { id = supply_Product.Supply_ProductID }, supply_Product);
        }

        // DELETE: api/Supply_Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply_Product(int id)
        {
            if (_context.Supply_Product == null)
            {
                return NotFound();
            }
            var supply_Product = await _context.Supply_Product.FindAsync(id);
            if (supply_Product == null)
            {
                return NotFound();
            }

            _context.Supply_Product.Remove(supply_Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Supply_ProductExists(int id)
        {
            return (_context.Supply_Product?.Any(e => e.Supply_ProductID == id)).GetValueOrDefault();
        }
    }
}
