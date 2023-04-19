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
    public class InsertsController : ControllerBase
    {
        private readonly DataContext _context;

        public InsertsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Inserts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Insert>>> GetInsert()
        {
          if (_context.Insert == null)
          {
              return NotFound();
          }
            return await _context.Insert.ToListAsync();
        }

        // GET: api/Inserts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insert>> GetInsert(int id)
        {
          if (_context.Insert == null)
          {
              return NotFound();
          }
            var insert = await _context.Insert.FindAsync(id);

            if (insert == null)
            {
                return NotFound();
            }

            return insert;
        }

        // PUT: api/Inserts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsert(int id, Insert insert)
        {
            if (id != insert.InsertID)
            {
                return BadRequest();
            }

            _context.Entry(insert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsertExists(id))
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

        // POST: api/Inserts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Insert>> PostInsert(Insert insert)
        {
          if (_context.Insert == null)
          {
              return Problem("Entity set 'DataContext.Insert'  is null.");
          }
            _context.Insert.Add(insert);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInsert", new { id = insert.InsertID }, insert);
        }

        // DELETE: api/Inserts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsert(int id)
        {
            if (_context.Insert == null)
            {
                return NotFound();
            }
            var insert = await _context.Insert.FindAsync(id);
            if (insert == null)
            {
                return NotFound();
            }

            _context.Insert.Remove(insert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InsertExists(int id)
        {
            return (_context.Insert?.Any(e => e.InsertID == id)).GetValueOrDefault();
        }
    }
}
