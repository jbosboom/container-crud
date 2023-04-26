using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContainerApi;

namespace ContainerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly ContainerCrudContext _context;

        public ContainerController(ContainerCrudContext context)
        {
            _context = context;
        }

        // GET: api/Container
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Container>>> GetContainers()
        {
          if (_context.Containers == null)
          {
              return NotFound();
          }
            return await _context.Containers.ToListAsync();
        }

        // GET: api/Container/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Container>> GetContainer(long id)
        {
            if (_context.Containers == null)
            {
                return NotFound();
            }
            var container = await _context.Containers.FindAsync(id);

            if (container == null)
            {
                return NotFound();
            }

            return container;
        }

        // PUT: api/Container/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContainer(long id, Container container)
        {
            if (id != container.ContainerKey)
            {
                return BadRequest();
            }

            _context.Entry(container).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContainerExists(id))
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

        // POST: api/Container
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Container>> PostContainer(Container container)
        {
            if (_context.Containers == null)
            {
                return Problem("Entity set 'ContainerCrudContext.Containers'  is null.");
            }
            _context.Containers.Add(container);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContainer", new { id = container.ContainerKey }, container);
        }

        // DELETE: api/Container/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContainer(long id)
        {
            if (_context.Containers == null)
            {
                return NotFound();
            }
            var container = await _context.Containers.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }

            _context.Containers.Remove(container);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContainerExists(long id)
        {
            return (_context.Containers?.Any(e => e.ContainerKey == id)).GetValueOrDefault();
        }
    }
}
