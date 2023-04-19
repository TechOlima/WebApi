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
    public class Order_ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public Order_ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Order_Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order_Product>>> GetOrder_Product()
        {
          if (_context.Order_Product == null)
          {
              return NotFound();
          }
            return await _context.Order_Product.ToListAsync();
        }

        // GET: api/Order_Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order_Product>> GetOrder_Product(int id)
        {
          if (_context.Order_Product == null)
          {
              return NotFound();
          }
            var order_Product = await _context.Order_Product.FindAsync(id);

            if (order_Product == null)
            {
                return NotFound();
            }

            return order_Product;
        }

        // PUT: api/Order_Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder_Product(int id, Order_Product order_Product)
        {
            if (id != order_Product.Order_ProductID)
            {
                return BadRequest();
            }

            _context.Entry(order_Product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Order_ProductExists(id))
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

        // POST: api/Order_Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order_Product>> PostOrder_Product(Order_Product order_Product)
        {
          if (_context.Order_Product == null)
          {
              return Problem("Entity set 'DataContext.Order_Product'  is null.");
          }
            _context.Order_Product.Add(order_Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder_Product", new { id = order_Product.Order_ProductID }, order_Product);
        }

        // DELETE: api/Order_Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder_Product(int id)
        {
            if (_context.Order_Product == null)
            {
                return NotFound();
            }
            var order_Product = await _context.Order_Product.FindAsync(id);
            if (order_Product == null)
            {
                return NotFound();
            }

            _context.Order_Product.Remove(order_Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Order_ProductExists(int id)
        {
            return (_context.Order_Product?.Any(e => e.Order_ProductID == id)).GetValueOrDefault();
        }
    }
}
