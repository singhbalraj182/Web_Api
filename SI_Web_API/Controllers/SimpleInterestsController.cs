using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SI_Web_API.Data;
using SI_Web_API.Models;

namespace SI_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleInterestsController : ControllerBase
    {
        private readonly SIDataContext _context;

        public SimpleInterestsController(SIDataContext context)
        {
            _context = context;
        }

        // GET: api/SimpleInterests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimpleInterest>>> GetSimpleInterests()
        {
            return await _context.SimpleInterests.ToListAsync();
        }

        // GET: api/SimpleInterests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SimpleInterest>> GetSimpleInterest(int id)
        {
            var simpleInterest = await _context.SimpleInterests.FindAsync(id);

            if (simpleInterest == null)
            {
                return NotFound();
            }

            return simpleInterest;
        }

        // PUT: api/SimpleInterests/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSimpleInterest(int id, SimpleInterest simpleInterest)
        {
            if (id != simpleInterest.Id)
            {
                return BadRequest();
            }

            _context.Entry(simpleInterest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimpleInterestExists(id))
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

        // POST: api/SimpleInterests
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SimpleInterest>> PostSimpleInterest(SimpleInterest simpleInterest)
        {
            _context.SimpleInterests.Add(simpleInterest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSimpleInterest", new { id = simpleInterest.Id }, simpleInterest);
        }

        // DELETE: api/SimpleInterests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SimpleInterest>> DeleteSimpleInterest(int id)
        {
            var simpleInterest = await _context.SimpleInterests.FindAsync(id);
            if (simpleInterest == null)
            {
                return NotFound();
            }

            _context.SimpleInterests.Remove(simpleInterest);
            await _context.SaveChangesAsync();

            return simpleInterest;
        }

        private bool SimpleInterestExists(int id)
        {
            return _context.SimpleInterests.Any(e => e.Id == id);
        }
    }
}
