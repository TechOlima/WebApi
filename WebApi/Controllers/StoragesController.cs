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
    public class StoragesController : ControllerBase
    {
        private readonly DataContext _context;

        public StoragesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Storages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StorageGet>>> GetStorage()
        {
          if (_context.Storage == null)
          {
              return NotFound();
          }
            return await _context.Storage.Include(i=> i.Product).Select(i=> new StorageGet(i)).ToListAsync();
        }

        // GET: api/Storages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Storage>> GetStorage(int id)
        {
          if (_context.Storage == null)
          {
              return NotFound();
          }
            var storage = await _context.Storage
                .Include(i=> i.Order)
                .Include(i=> i.Product)
                .Include(i=> i.Supply)
                .Where(i=> i.StorageID == id)
                .FirstOrDefaultAsync();

            if (storage == null)
            {
                return NotFound();
            }

            return storage;
        }

        // PUT: api/Storages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStorage(int id, StoragePut storagePut)
        {
            Storage storage = new Storage(storagePut);

            if (id != storage.StorageID)
            {
                return BadRequest();
            }

            _context.Entry(storage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StorageExists(id))
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

        // POST: api/Storages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Storage>> PostStorage(StoragePost storagePost)
        {
            Storage storage = new Storage(storagePost);
            if (_context.Storage == null)
          {
              return Problem("Entity set 'DataContext.Storage'  is null.");
          }
            _context.Storage.Add(storage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStorage", new { id = storage.StorageID }, storage);
        }

        // DELETE: api/Storages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStorage(int id)
        {
            if (_context.Storage == null)
            {
                return NotFound();
            }
            var storage = await _context.Storage.FindAsync(id);
            if (storage == null)
            {
                return NotFound();
            }

            _context.Storage.Remove(storage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StorageExists(int id)
        {
            return (_context.Storage?.Any(e => e.StorageID == id)).GetValueOrDefault();
        }
    }
}
