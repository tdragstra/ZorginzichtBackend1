using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZorginzichtBackend.Models;
using System.Runtime.CompilerServices;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly BloggingContext _context;

        public PoliciesController(BloggingContext context)
        {
            _context = context;
        }

        // GET: api/Policies
        [HttpGet]
        public async Task<List<Policy>> Getpolicies()
        {

            var policies = await _context.policies
                .Include(x => x.Customer)
                .Include(z => z.Invoices)
                .ToListAsync();
            /*var policies = await _context.policies.Include(x => x.Customer).ThenInclude(y => y.invoices).ToListAsync();*/
            return policies;
        }

        // GET: api/Policies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Policy>> GetPolicy(int id)
        {
          if (_context.policies == null)
          {
              return NotFound();
          }
            var policy = await _context.policies.FindAsync(id);

            if (policy == null)
            {
                return NotFound();
            }

            return policy;
        }

        // PUT: api/Policies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolicy(int id, Policy policy)
        {
            if (id != policy.id)
            {
                return BadRequest();
            }

            _context.Entry(policy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PolicyExists(id))
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

        // POST: api/Policies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Policy>> PostPolicy(Policy policy)
        {
          if (_context.policies == null)
          {
              return Problem("Entity set 'BloggingContext.policies'  is null.");
          }
            _context.policies.Add(policy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolicy", new { id = policy.id }, policy);
        }

        // DELETE: api/Policies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolicy(int id)
        {
            if (_context.policies == null)
            {
                return NotFound();
            }
            var policy = await _context.policies.FindAsync(id);
            if (policy == null)
            {
                return NotFound();
            }

            _context.policies.Remove(policy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PolicyExists(int id)
        {
            return (_context.policies?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
