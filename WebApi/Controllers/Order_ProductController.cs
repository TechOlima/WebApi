using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class Order_ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public Order_ProductController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Order_Product
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Order_ProductGet>>> GetOrderProduct()
        {
          if (_context.OrderProduct == null)
          {
              return NotFound();
          }
            return await _context.OrderProduct.Include(i=> i.Product).Select(i=> new Order_ProductGet(i)).ToListAsync();
        }

        // GET: api/Order_Product/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Order_ProductGet>> GetOrder_Product(int id)
        {
          if (_context.OrderProduct == null)
          {
              return NotFound();
          }
            var order_Product = await _context.OrderProduct.Include(i => i.Product)
                .FirstOrDefaultAsync(i => i.Order_ProductID == id);

            if (order_Product == null)
            {
                return NotFound();
            }

            return new Order_ProductGet(order_Product);
        }

        // PUT: api/Order_Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder_Product(int id, Order_ProductPut order_ProductPut)
        {
            if (id != order_ProductPut.Order_ProductID)
            {
                return BadRequest();
            }

            Order_Product order_Product = new Order_Product(order_ProductPut);

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
        public async Task<ActionResult<Order_Product>> PostOrder_Product(Order_ProductPost order_ProductPost)
        {
          if (_context.OrderProduct == null)
          {
              return Problem("Entity set 'DataContext.OrderProduct'  is null.");
          }
            Order_Product order_Product = new Order_Product(order_ProductPost);

            _context.OrderProduct.Add(order_Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder_Product", new { id = order_Product.Order_ProductID }, order_Product);
        }

        // DELETE: api/Order_Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder_Product(int id)
        {
            if (_context.OrderProduct == null)
            {
                return NotFound();
            }
            var order_Product = await _context.OrderProduct.FindAsync(id);
            if (order_Product == null)
            {
                return NotFound();
            }

            _context.OrderProduct.Remove(order_Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Order_ProductExists(int id)
        {
            return (_context.OrderProduct?.Any(e => e.Order_ProductID == id)).GetValueOrDefault();
        }
    }
}
