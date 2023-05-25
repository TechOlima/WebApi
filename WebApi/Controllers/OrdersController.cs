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
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderGet>>> GetOrder(string? SearchPattern)
        {
          if (_context.Order == null)
          {
              return NotFound();
          }
            return await _context.Order
                .Include(i=> i.State)
                .Include(i => i.Storages)
                .ThenInclude(p => p.Product)
                .Where(i => String.IsNullOrEmpty(i.ClientName) ||
                    String.IsNullOrEmpty(SearchPattern) ||
                    (!String.IsNullOrEmpty(SearchPattern) && i.ClientName.ToLower().Contains(SearchPattern.ToLower())))
                .Select(i=> new OrderGet(i))
                .ToListAsync();            
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderGet>> GetOrder(int id)
        {
          if (_context.Order == null)
          {
              return NotFound();
          }
            var order = new OrderGet(await _context.Order
                .Include(i => i.State)
                .Include(i => i.Storages)
                .ThenInclude(p=>p.Product)                
                .FirstOrDefaultAsync(i => i.OrderID == id));

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, OrderPut orderPut)
        {
            Order order= new Order(orderPut, _context);

            if (id != order.OrderID)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(OrderPost orderPost)
        {
            Order order = new Order(orderPost, _context);
            if (_context.Order == null)
          {
              return Problem("Entity set 'DataContext.Order'  is null.");
          }
            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Order == null)
            {
                return NotFound();
            }
            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            //удаляем связанных товары на складе
            Storage[] storages = _context.Storage.Where(i => i.OrderID == order.OrderID).ToArray();

            foreach (Storage storage in storages) storage.OrderID = null;

            _context.Storage.UpdateRange(storages);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
