using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZorginzichtBackend.Models;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditonalInsurrancesController : ControllerBase
    {
        private readonly BloggingContext _context;

        public AdditonalInsurrancesController(BloggingContext context)
        {
            _context = context;
        }

        // GET: api/AdditonalInsurrances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditonalInsurrance>>> Getadditional_insurances()
        {
          if (_context.additional_insurances == null)
          {
              return NotFound();
          }
            return await _context.additional_insurances.ToListAsync();
        }

        // GET: api/AdditonalInsurrances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdditonalInsurrance>> GetAdditonalInsurrance(int id)
        {
          if (_context.additional_insurances == null)
          {
              return NotFound();
          }
            var additonalInsurrance = await _context.additional_insurances.FindAsync(id);

            if (additonalInsurrance == null)
            {
                return NotFound();
            }

            return additonalInsurrance;
        }

        // PUT: api/AdditonalInsurrances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditonalInsurrance(int id, AdditonalInsurrance additonalInsurrance)
        {
            if (id != additonalInsurrance.id)
            {
                return BadRequest();
            }

            _context.Entry(additonalInsurrance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditonalInsurranceExists(id))
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

        // POST: api/AdditonalInsurrances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdditonalInsurrance>> PostAdditonalInsurrance(AdditonalInsurrance additonalInsurrance)
        {
          if (_context.additional_insurances == null)
          {
              return Problem("Entity set 'BloggingContext.additional_insurances'  is null.");
          }
            _context.additional_insurances.Add(additonalInsurrance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditonalInsurrance", new { id = additonalInsurrance.id }, additonalInsurrance);
        }

        // DELETE: api/AdditonalInsurrances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdditonalInsurrance(int id)
        {
            if (_context.additional_insurances == null)
            {
                return NotFound();
            }
            var additonalInsurrance = await _context.additional_insurances.FindAsync(id);
            if (additonalInsurrance == null)
            {
                return NotFound();
            }

            _context.additional_insurances.Remove(additonalInsurrance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdditonalInsurranceExists(int id)
        {
            return (_context.additional_insurances?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
