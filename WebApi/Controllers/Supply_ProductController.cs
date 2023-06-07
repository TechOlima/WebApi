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
    public class Supply_ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public Supply_ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Supply_Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply_ProductGet>>> GetSupplyProduct()
        {
          if (_context.SupplyProduct == null)
          {
              return NotFound();
          }
            return await _context.SupplyProduct.Include(i => i.Product).Select(i => new Supply_ProductGet(i)).ToListAsync();
        }

        // GET: api/Supply_Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply_Product>> GetSupply_Product(int id)
        {
          if (_context.SupplyProduct == null)
          {
              return NotFound();
          }
            var supply_Product = await _context.SupplyProduct.Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Supply_ProductID == id);

            if (supply_Product == null)
            {
                return NotFound();
            }

            return supply_Product;
        }

        // PUT: api/Supply_Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply_Product(int id, Supply_ProductPut supply_ProductPut)
        {
            if (id != supply_ProductPut.Supply_ProductID)
            {
                return BadRequest();
            }
            Supply_Product supply_Product = new Supply_Product(supply_ProductPut);

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
        public async Task<ActionResult<Supply_Product>> PostSupply_Product(Supply_ProductPost supply_ProductPost)
        {
          if (_context.SupplyProduct == null)
          {
              return Problem("Entity set 'DataContext.SupplyProduct'  is null.");
          }

            Supply_Product supply_Product = new Supply_Product(supply_ProductPost);

            _context.SupplyProduct.Add(supply_Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupply_Product", new { id = supply_Product.Supply_ProductID }, supply_Product);
        }

        // DELETE: api/Supply_Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply_Product(int id)
        {
            if (_context.SupplyProduct == null)
            {
                return NotFound();
            }
            var supply_Product = await _context.SupplyProduct.FindAsync(id);
            if (supply_Product == null)
            {
                return NotFound();
            }

            _context.SupplyProduct.Remove(supply_Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Supply_ProductExists(int id)
        {
            return (_context.SupplyProduct?.Any(e => e.Supply_ProductID == id)).GetValueOrDefault();
        }
    }
}
