using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Classes;
using WebApi.Classes.Operations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ProductGet>>> GetProduct(string? SearchPattern)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }            

            return await _context.Product
                .Include(i => i.ProductType)
                .Include(i => i.MaterialType)
                .Include(i=> i.GenderType)                
                .Include(i => i.Photos)
                .Where(i => String.IsNullOrEmpty(i.Name) ||
                    String.IsNullOrEmpty(SearchPattern) ||
                    (!String.IsNullOrEmpty(SearchPattern) && i.Name.ToLower().Contains(SearchPattern.ToLower())))                
                .Select(i => new ProductGet(i))
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<ProductGet> GetProduct(int id)
        {
          if (_context.Product == null)
          {
              return NotFound();
          }
            var product = _context.Product
                .Include(i=> i.ProductType)
                .Include(i => i.MaterialType)
                .Include(i => i.Inserts).ThenInclude(i => i.StoneType)
                .Include(i => i.Photos)
                .Include(i => i.GenderType)                
                .Where(i => i.ProductID == id)
                .Select(i => new ProductGet(i))
                .FirstOrDefault();            

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, ProductPut productPut)
        {
            Product product = new Product(productPut, _context);            

            if (id != product.ProductID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]        
        public async Task<ActionResult<ProductGet>> PostProduct(ProductPost productPost)
        {
            Product product = new Product(productPost, _context);

            if (_context.Product == null)
            {
                return Problem("Entity set 'DataContext.Product'  is null.");
            }          

            _context.Product.Add(product);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetProduct", new { id = product.ProductID }, new ProductGet(product));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Product?.Any(e => e.ProductID == id)).GetValueOrDefault();
        }
    }
}
