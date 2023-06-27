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
    public class ProductTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ProductTypes
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductType()
        {
          if (_context.ProductType == null)
          {
              return NotFound();
          }
            return await _context.ProductType.ToListAsync();
        }

        // GET: api/ProductTypes/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
          if (_context.ProductType == null)
          {
              return NotFound();
          }
            var productType = await _context.ProductType.FindAsync(id);

            if (productType == null)
            {
                return NotFound();
            }

            return productType;
        }

        // PUT: api/ProductTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductType(int id, ProductType productType)
        {
            if (id != productType.ProductTypeID)
            {
                return BadRequest();
            }

            _context.Entry(productType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // POST: api/ProductTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductType>> PostProductType(ProductType productType)
        {
          if (_context.ProductType == null)
          {
              return Problem("Entity set 'DataContext.ProductType'  is null.");
          }
            _context.ProductType.Add(productType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductType", new { id = productType.ProductTypeID }, productType);
        }

        // DELETE: api/ProductTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductType(int id)
        {
            if (_context.ProductType == null)
            {
                return NotFound();
            }
            var productType = await _context.ProductType.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            _context.ProductType.Remove(productType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductTypeExists(int id)
        {
            return (_context.ProductType?.Any(e => e.ProductTypeID == id)).GetValueOrDefault();
        }
    }
}
