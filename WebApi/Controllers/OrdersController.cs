using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.Classes;
using WebApi.Classes.Operations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration Configuration;
        private readonly string QuenueServiceUrl;

        public OrdersController(DataContext context, IConfiguration configRoot)
        {
            _context = context;
            Configuration = configRoot;
            QuenueServiceUrl = Configuration.GetValue<string>("QuenueServiceUrl");
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
                .Include(i => i.OrderProducts)
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
                .Include(i => i.OrderProducts)
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchOrder(int id, string state)
        {
            Order? order = _context.Order.FirstOrDefault(i=> i.OrderID == id);
            State? newstate = _context.State.FirstOrDefault(i=> i.Name.ToLower() == state.ToLower());

            if (order == null || newstate == null) return NotFound(); 
            else
            {
                order.State = newstate;
                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                //отправка сообщений в очередь
                if (order.SmsNotification == true && order.ClientPhone != null)                
                    await SendNotification("sms", order.ClientPhone, "Статус заказа изменился на: " + order.State.Name); 
                
                if (order.EmailNotification == true && order.ClientEmail != null)                
                    await SendNotification("email", order.ClientEmail, "Статус заказа изменился на: " + order.State.Name);                    
                
                return NoContent();
            }
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

            //отправка сообщений в очередь
            if (order.SmsNotification == true && order.ClientPhone != null)
                await SendNotification("sms", order.ClientPhone, "Создан новый заказ:" + order.OrderID);

            if (order.EmailNotification == true && order.ClientEmail != null)
                await SendNotification("email", order.ClientEmail, "Создан новый заказ:" + order.OrderID);

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
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> SendNotification(string queueName, string adress, string mes)
        {
            HttpClient httpClient = new HttpClient();
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, QuenueServiceUrl + "/api/Azure/InsertMessage");

            string message = JsonConvert.SerializeObject(new Notification()
            {
                Adress = adress,
                Message = mes
            }, Newtonsoft.Json.Formatting.Indented);            

            Dictionary<string, string> data = new Dictionary<string, string>
            {
                ["queueName"] = queueName,
                ["message"] = message
            };
            // создаем объект HttpContent
            HttpContent contentForm = new FormUrlEncodedContent(data);
            request.Content = contentForm;
            using HttpResponseMessage response = await httpClient.SendAsync(request);

            string requestStr = response.RequestMessage.ToString();
            var responseStr = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) return true;
            else return false;
        }

        private bool OrderExists(int id)
        {
            return (_context.Order?.Any(e => e.OrderID == id)).GetValueOrDefault();
        }
    }
}
