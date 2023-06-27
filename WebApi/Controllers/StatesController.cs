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
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/States
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<State>>> GetState()
        {
          if (_context.State == null)
          {
              return NotFound();
          }
            return await _context.State.ToListAsync();
        }

        // GET: api/States/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<State>> GetState(int id)
        {
          if (_context.State == null)
          {
              return NotFound();
          }
            var state = await _context.State.FindAsync(id);

            if (state == null)
            {
                return NotFound();
            }

            return state;
        }

        // PUT: api/States/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutState(int id, State state)
        {
            if (id != state.StateID)
            {
                return BadRequest();
            }

            _context.Entry(state).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StateExists(id))
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

        // POST: api/States
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<State>> PostState(State state)
        {
          if (_context.State == null)
          {
              return Problem("Entity set 'DataContext.State'  is null.");
          }
            _context.State.Add(state);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetState", new { id = state.StateID }, state);
        }

        // DELETE: api/States/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            if (_context.State == null)
            {
                return NotFound();
            }
            var state = await _context.State.FindAsync(id);
            if (state == null)
            {
                return NotFound();
            }

            _context.State.Remove(state);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StateExists(int id)
        {
            return (_context.State?.Any(e => e.StateID == id)).GetValueOrDefault();
        }
    }
}
