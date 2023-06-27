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
    public class InsertsController : ControllerBase
    {
        private readonly DataContext _context;

        public InsertsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Inserts
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<InsertGet>>> GetInsert()
        {
          if (_context.Insert == null)
          {
              return NotFound();
          }
            return await _context.Insert
                .Include(i => i.Product)
                .Include(i => i.StoneType)
                .Select(i=> new InsertGet(i)).ToListAsync();
        }

        // GET: api/Inserts/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<InsertGet>> GetInsert(int id)
        {
          if (_context.Insert == null)
          {
              return NotFound();
          }
            var insert = await _context.Insert
                .Include(i=> i.Product)
                .Include(i => i.StoneType)
                .Where(i => i.InsertID == id).Select(i => new InsertGet(i)).FirstOrDefaultAsync();

            if (insert == null)
            {
                return NotFound();
            }

            return insert;
        }

        // PUT: api/Inserts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsert(int id, InsertPut insert)
        {
            if (id != insert.InsertID)
            {
                return BadRequest();
            }            

            _context.Entry(new Insert(insert, _context)).State = EntityState.Modified;

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
        public async Task<ActionResult<Insert>> PostInsert(InsertPost insertPost)
        {
          if (_context.Insert == null)
          {
              return Problem("Entity set 'DataContext.Insert'  is null.");
          }
            var insert = new Insert(insertPost, _context);

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
